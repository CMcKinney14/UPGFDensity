using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Security;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;
using static System.Windows.Forms.LinkLabel;

namespace UPGFDensity
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string PrevDirPath;
            string effDate = txtEffDate.Text.Substring(0, 6);
            string newPath = "";
            string OutputPath = txtOutputPath.Text;
            PrevDirPath = txtPrevRelDir.Text;
            newPath = txtOutputPath.Text + "\\New" + effDate;
            string CzarFolder = "";
            string RatewareFolder = "";
            string relNum = txtRelNum.Text.Substring(0, 2);
            string PrevrelNum = txtPrevRel.Text.Substring(0, 2);
            char reletter = ' ';
            List <decimal> type1Fac = new List<decimal>();
            List<decimal> type2Fac = new List<decimal>();

            type1Fac = GetList1();
            type2Fac = GetList2();

            var Canlines = new List<string>();
            Canlines = File.ReadAllLines(txtCanRatesFile.Text).Where(x => x != "\u001a").Distinct().ToList();
            if (Char.IsLetter(Canlines[0][0])) ///////////Removed header
            {
                Canlines.RemoveAt(0);
            }

            var USlines = new List<string>();
            USlines = File.ReadAllLines(txtUSRatesFile.Text).Where(x => x != "\u001a").Distinct().ToList();
            if (Char.IsLetter(USlines[0][0])) ///////////Removed header
            {
                USlines.RemoveAt(0);
            }


            List<string> RBNlines = new List<string>();
            RBNlines = File.ReadAllLines(txtRBNtableFile.Text).Where(x => x != "\u001a").Distinct().ToList();
            string [] Test = RBNlines[0].Split(',');
            if (Test[2].Any(char.IsLetter))
            {
               RBNlines.RemoveAt(0);
            }

            /////////////////////////////////////////////////////////////Deletes if one exist

            if (Directory.Exists(newPath)) { Directory.Delete(newPath, true); }

            /////////////////////////////////////////////////////////////Build the Folder and edit support Files
            
            if (Directory.Exists(newPath)) 
            { 
                Directory.Delete(newPath, true); 
            }

            /////////////////////////////////////////////////////////////Creates Directories

            Directory.CreateDirectory(newPath + "\\Rateware\\Density");
            CloneDirectory(PrevDirPath + "\\Rateware\\Density", newPath + "\\Rateware\\Density");
            RatewareFolder = newPath + "\\Rateware\\Density\\";

            SupportForms SF = new SupportForms();
            SF.ModuleIds(RatewareFolder, txtRelNum.Text, txtPi.Text, txtEffDate.Text);
            SF.RWxmls(RatewareFolder, relNum, PrevrelNum);

            Cleaner(newPath); ///////////////////////////////Removes all old RWM files

            MTX(RBNlines, newPath, relNum);

            MinFileBuilder(USlines, Canlines,newPath,relNum);

            RateFileBuilder(USlines, Canlines, newPath, relNum, type1Fac,type2Fac);

            Dataset(newPath, relNum, PrevDirPath, txtEffDate.Text,Canlines,USlines);

            Renamer(RatewareFolder, PrevrelNum, relNum); ///// Renames all RWFiles with updated Rel Number that are caried over

            string folderPath = RatewareFolder + "work";
            if (Directory.Exists(folderPath))
            {
                Directory.Delete(folderPath,true);
            }

            MessageBox.Show("Complete.");
        }




        public static void Dataset(string path, string relNum, string PrevPath, string effDate,List<string>CanList,List<string>USList)
        {
            /////Brings it over
            CloneDirectory(PrevPath + "\\DataSet", path + "\\DataSet");

            ///// Base
            string[] filePaths = Directory.GetFiles(path + "\\DataSet","580base*");
            string yr = effDate.Substring(2, 2);
            string mm = effDate.Substring(4, 2);
            string day = effDate.Substring(6, 2);
            string date = yr+ mm + day;
            foreach (var item in filePaths)
            {
                List<string> data = new List<string>();
                data = File.ReadAllLines(item).Where(x => x != "\u001a").ToList();
                File.Delete(item);

                for (int i = 0; i < data.Count; i++)
                {
                    data[i] = data[i].Substring(0,7) + date;
                }

                File.WriteAllLines(item,data);
            }
            
            /////// mtxCan
             filePaths = Directory.GetFiles(path + "\\Rateware\\Density\\UPF5800C", "*mtx*");
            List<string> tempdata = new List<string>();
            List<string> MTXdata = new List<string>();
            MTXdata = File.ReadAllLines(filePaths[0]).Where(x => x != "\u001a").ToList();
            foreach (string sRecord in MTXdata)
            {
                
                string zip1 = sRecord.Substring(0, 3);
                string zip2 = sRecord.Substring(6, 3);
               string rbn = sRecord.Substring(20, 5);
                rbn = rbn.PadLeft(6, '0');
               string ro = zip1 + zip2 + rbn + " " + date;
                tempdata.Add(ro);
            }


            File.Delete(path + "\\DataSet\\580rbnCN.tap");
            File.WriteAllLines(path + "\\DataSet\\580rbnCN.tap",tempdata);
            tempdata.Clear();
            MTXdata.Clear();


            //////// mtxUS
            filePaths = Directory.GetFiles(path + "\\Rateware\\Density\\UPF5800U", "*mtx*");           
            MTXdata = File.ReadAllLines(filePaths[0]).Where(x => x != "\u001a").ToList();
            foreach (string sRecord in MTXdata)
            {
                string zip1 = sRecord.Substring(0, 3);
                string zip2 = sRecord.Substring(6, 3);
                string rbn = sRecord.Substring(20, 5);
                rbn = rbn.PadLeft(6, '0');
                string ro = zip1 + zip2 + rbn + " " + date;
                tempdata.Add(ro);

            }

            File.Delete(path + "\\DataSet\\580rbnUS.tap");
            File.WriteAllLines(path + "\\DataSet\\580rbnUS.tap", tempdata);
            tempdata.Clear();


            ////////////////////////Rates
            ///from the origin data
            File.Delete(path + "\\DataSet\\580rtsUS.tap");
            File.Delete(path + "\\DataSet\\580rtsCN.tap");


            ///US
            foreach  (string item in USList)
            {
                string newLine = "";
                string rates = "";
                string oldRate = "";
                string newRate = "";
                string[] data = item.Split(',');
                string rbn = data[0].PadLeft(5, '0');
                string formula = data[1].PadLeft(3, '0');

                for (int i = 2; i < data.Count(); i++)
                {
                    
                    oldRate = data[i];
                    if (!oldRate.Contains("."))
                    {
                        oldRate += ".00";
                    }
                    else if (oldRate.Substring(oldRate.IndexOf(".") + 1).Length < 2)
                    {
                        oldRate += "0";
                    }

                    newRate = oldRate.Replace(".", "");
                    newRate = newRate.PadLeft(6, '0');
                    rates = rates + newRate;
                } 
                newLine = rbn + " " + formula + rates + "000000000000000000 " + date;

                tempdata.Add(newLine);

            }

            File.WriteAllLines(path + "\\DataSet\\580rtsUS.tap", tempdata);
            tempdata.Clear();

            ////CAN

            foreach (string item in CanList)
            {
                string newLine = "";
                string rates = "";
                string oldRate = "";
                string newRate = "";
                string[] data = item.Split(',');
                string rbn = data[0].Substring(1, 5);
                string formula = data[1].PadLeft(3,'0');

                for (int i = 2; i < data.Count(); i++)
                {

                    oldRate = data[i];
                    if (!oldRate.Contains("."))
                    {
                        oldRate += ".00";
                    }
                    else if (oldRate.Substring(oldRate.IndexOf(".") + 1).Length < 2)
                    {
                        oldRate += "0";
                    }

                    newRate = oldRate.Replace(".", "");
                    newRate = newRate.PadLeft(6, '0');
                    rates = rates + newRate;
                }
                newLine = rbn + " " + formula + rates + "000000000000000000 " + date;

                tempdata.Add(newLine);
            }

            File.WriteAllLines(path + "\\DataSet\\580rtsCN.tap", tempdata);
            tempdata.Clear();

            //////////////Fac
            ///carry over
            filePaths = Directory.GetFiles(path + "\\DataSet", "580fac*");
            
            foreach (var item in filePaths)
            {
                List<string> data = new List<string>();
                data = File.ReadAllLines(item).Where(x => x != "\u001a").ToList();
                File.Delete(item);

                for (int i = 0; i < data.Count; i++)
                {
                    data[i] = data[i].Substring(0, 62) + date;
                }

                File.WriteAllLines(item, data);
            }


        }

            public static void MinFileBuilder(List<string> USList, List<string> CanList,string path,string relNum)
        {
            List<string> USMinWithRBN = new List<string>();
            List<string> CanMinWithRBN = new List<string>();
            string MinCharge = "";
            string sRbn = "";
            string[] data;
            foreach (string s in USList)
            {
                data = s.Split(',');
                sRbn = data[0];
                sRbn = sRbn.PadLeft(8, '0');
                MinCharge = data[2];
                if (!MinCharge.Contains("."))
                { 
                    MinCharge = MinCharge + ".00"; 
                }

                decimal my_decimal;
                if (decimal.TryParse(MinCharge, out my_decimal))
                {
                    int decimal_places = BitConverter.GetBytes(decimal.GetBits(my_decimal)[3])[2];
                    if (decimal_places < 2)
                    {
                        MinCharge = MinCharge + "0";
                    }
                }

                MinCharge = MinCharge.Replace(".", "");
                MinCharge = MinCharge.PadLeft(6, '0');
                USMinWithRBN.Add("00001"  + sRbn + " 000001000000000000MC        " + MinCharge);
            }

            foreach (string s in CanList)
            {
                data = s.Split(',');
                sRbn = data[0];
                sRbn = sRbn.PadLeft(8, '0');
                MinCharge = data[2];
                if (!MinCharge.Contains("."))
                {
                    MinCharge = MinCharge + ".00";
                }

                decimal my_decimal;
                if (decimal.TryParse(MinCharge, out my_decimal))
                {
                    int decimal_places = BitConverter.GetBytes(decimal.GetBits(my_decimal)[3])[2];
                    if (decimal_places < 2)
                    {
                        MinCharge = MinCharge + "0";
                    }
                }
                MinCharge = MinCharge.Replace(".", "");
                MinCharge = MinCharge.PadLeft(6, '0');
                CanMinWithRBN.Add("00001"  + sRbn + " 000001000000000000MC        " + MinCharge);
            }
            
            File.WriteAllLines(path + "\\Rateware\\Density\\UPF5800U\\" + "upf5800u.min" + relNum +".fil", USMinWithRBN);
            File.WriteAllLines(path + "\\Rateware\\Density\\UPF5800C\\" + "upf5800c.min" + relNum + ".fil", CanMinWithRBN);
        }


        public static void RateFileBuilder(List<string> USList, List<string> CanList, string path, string relNum,List<decimal>fac1List,List<decimal>fac2List)
        {
            List<string> lines = new List<string>();
            string ClassLine = "";
            int x = 0;
            ///////////////US Rates
            foreach (string data in USList)
            {   string newLine = "";
                string rateLine = data;
                decimal DenRate = 0;
                string[] rateArr = rateLine.Split(',');
                
                string densityLine = "";
                
                string flag = rateArr[1];
                string rbn = rateArr[0].PadLeft(8, '0');


                        if (flag == "1")
                        {
                            for (int d = 0; d < fac1List.Count; d++)
                             {
                                 decimal fac = fac1List[d];

                                    for (int i = 3; i <= rateArr.Length - 1; i++)
                                    {

                                     string sRate = rateArr[i];
                                    decimal dRate = Convert.ToDecimal(sRate);
                            
                                    DenRate = dRate * fac;

                                     string formattedDecimal = DenRate.ToString("0.00");
                                    formattedDecimal = formattedDecimal.Replace(".", "").PadLeft(6, '0');

                                    ClassLine = ClassLine + formattedDecimal;
                                    }

                             }
                            densityLine = densityLine + ClassLine;
                            ClassLine = "";

                         }

                        if (flag == "2")
                        {
                            for (int d = 0; d < fac2List.Count; d++)
                            {
                                decimal fac = fac2List[d];

                                for (int i = 3; i <= rateArr.Length - 1; i++)
                                {

                                    string sRate = rateArr[i];
                                    decimal dRate = Convert.ToDecimal(sRate);

                                    DenRate = dRate * fac;

                                    string formattedDecimal = DenRate.ToString("0.00");
                                    formattedDecimal = formattedDecimal.Replace(".", "").PadLeft(6, '0');

                                    ClassLine = ClassLine + formattedDecimal;
                                }

                            }
                            densityLine = densityLine + ClassLine;
                            ClassLine = "";

                        }

                lines.Add("00001" + rbn + " " + densityLine);
            }

            File.WriteAllLines(path + "\\Rateware\\Density\\UPF5800U\\" + "upf5800u.rte" + relNum + ".fil", lines);
            lines.Clear();


            ////////////////CAN Rates
            foreach (string data in CanList)
            {
                string newLine = "";
                string rateLine = data;
                decimal DenRate = 0;
                string[] rateArr = rateLine.Split(',');

                string densityLine = "";

                string flag = rateArr[1];
                string rbn = rateArr[0].PadLeft(8, '0');


                if (flag == "1")
                {
                    for (int d = 0; d < fac1List.Count; d++)
                    {
                        decimal fac = fac1List[d];

                        for (int i = 3; i <= rateArr.Length - 1; i++)
                        {

                            string sRate = rateArr[i];
                            decimal dRate = Convert.ToDecimal(sRate);

                            DenRate = dRate * fac;

                            string formattedDecimal = DenRate.ToString("0.00");
                            formattedDecimal = formattedDecimal.Replace(".", "").PadLeft(6, '0');

                            ClassLine = ClassLine + formattedDecimal;
                        }

                    }
                    densityLine = densityLine + ClassLine;
                    ClassLine = "";

                }

                if (flag == "2")
                {
                    for (int d = 0; d < fac2List.Count; d++)
                    {
                        decimal fac = fac2List[d];
                        for (int i = 3; i <= rateArr.Length - 1; i++)
                        {
                            string sRate = rateArr[i];
                            decimal dRate = Convert.ToDecimal(sRate);

                            DenRate = dRate * fac;

                            string formattedDecimal = DenRate.ToString("0.00");
                            formattedDecimal = formattedDecimal.Replace(".", "").PadLeft(6, '0');

                            ClassLine = ClassLine + formattedDecimal;
                        }

                    }
                    densityLine = densityLine + ClassLine;
                    ClassLine = "";

                }

                lines.Add("00001" + rbn + " " + densityLine);
            }

            File.WriteAllLines(path + "\\Rateware\\Density\\UPF5800C\\" + "upf5800c.rte" + relNum + ".fil", lines);
            lines.Clear();

        }




            public static void MTX(List<string> RBNtblFile, string path, string relNum)
            {
            int cnt = 0;
            string origin = "";
            string dest = "";
            string rbn = "";
            List<string> mtxCanlist = new List<string>();
            List<string> mtxUSlist = new List<string>();

            foreach (var item in RBNtblFile)
                {

                string[] data = item.Split(',');

                    if (data[0].Any(char.IsLetter))
                    {
                        origin = data[0];
                        origin = origin + "0A";

                    }
                    else
                    {
                        origin = data[0];
                        origin = origin + "00";
                     }




                    //////////////Dest
                if (data[1].Any(char.IsLetter))
                {
                    dest = data[1];
                    dest = dest + "0A";

                }
                else
                {
                    dest = data[1];
                    dest = dest.PadRight(5,'0');
                }

                rbn = data[2];
                rbn = rbn.PadLeft(8,'0');

                string finalLine = origin + " " + dest + " 00001" + rbn+ " " + "YN";
                if (finalLine.Length != 28)
                {
                    finalLine = "";
                }

                if (Convert.ToInt32(data[2]) >= 500000  && finalLine.Length == 28)
                {
                    mtxCanlist.Add(finalLine);
                }

                if (Convert.ToInt32(data[2]) < 500000 && finalLine.Length == 28)
                {
                    mtxUSlist.Add(finalLine);
                }

            }
            mtxCanlist.Sort();
            mtxUSlist.Sort();
            File.WriteAllLines(path + "\\Rateware\\Density\\UPF5800U\\" + "upf5800u.mtx" + relNum + ".fil", mtxUSlist);
            File.WriteAllLines(path + "\\Rateware\\Density\\UPF5800C\\" + "upf5800c.mtx" + relNum + ".fil", mtxCanlist);
            mtxCanlist.Clear();
            mtxUSlist.Clear();

        }


        public static void facMaker(string root, string PrevrelNum, string relNum)
        {//Renames the files with new release Number//
            string[] entries = Directory.GetFileSystemEntries(root, "*", SearchOption.AllDirectories);
            foreach (string name in entries)
            {
                if (name.Contains(PrevrelNum + ".fil"))
                {
                    string Beginning = name.Substring(0, name.Length - 6);
                    ////////////////Skips the created files during the IPA
                    if (!File.Exists(Beginning + relNum + ".fil"))
                    {
                        File.Move(name, Beginning + relNum + ".fil");
                    }
                    else
                    {
                        File.Delete(name);
                    }
                }
            }
        }







        public static void Renamer(string root, string PrevrelNum, string relNum)
            {//Renames the files with new release Number//
            string[] entries = Directory.GetFileSystemEntries(root, "*", SearchOption.AllDirectories);
                foreach (string name in entries)
                {
                    if (name.Contains(PrevrelNum + ".fil"))
                    {
                        string Beginning = name.Substring(0, name.Length - 6);
                        ////////////////Skips the created files during the IPA
                        if (!File.Exists(Beginning + relNum + ".fil"))
                        {
                            File.Move(name, Beginning + relNum + ".fil");
                        }
                        else
                        {
                            File.Delete(name);
                        }
                    }
                }
             }


        public static void Cleaner(string newPath)
        {//Renames the files with new release Number//
            string[] filePaths = Directory.GetFiles(newPath + "\\Rateware\\Density\\UPF5800C");
            foreach (string filePath in filePaths)
            {
                string[] path = filePath.Split('\\');
                if (path[6].Contains("upf5800c."))
                {
                    if (!path[6].Contains(".bse") && (!path[6].Contains(".adj") && (!path[6].Contains(".lab")))) ////////////Bse file carries over
                    {
                        File.Delete(filePath);
                    }
                }
            }

            filePaths = Directory.GetFiles(newPath + "\\Rateware\\Density\\UPF5800U");
            foreach (string filePath in filePaths)
            {
                string[] path = filePath.Split('\\');
                if (path[6].Contains("upf5800u."))
                {
                    if (!path[6].Contains(".bse") && (!path[6].Contains(".adj") && (!path[6].Contains(".lab"))))////////////Bse file carries over
                    {
                        File.Delete(filePath);
                    }


                }
            }
        }


        List<decimal> GetList1()
        {
            List<decimal> list = new List<decimal>();

            string fac = "6.1930 4.9240 4.3150 3.7060 3.4195 3.1330 2.8225 2.5120 2.3570 2.2020 2.0475 1.8930 1.7360 1.5790 1.4865 1.3940 1.3305 1.2670 1.2343 1.2017 1.1690 1.1407 1.1123 1.0840 1.0560 1.0280 1.0000 0.9733 0.9467 0.9200 0.9200 0.9133 0.9133 0.9067 0.9067 0.9000 0.9000 0.8933 0.8933 0.8867 0.8867 0.8800 0.8800 0.8733 0.8733 0.8667 0.8667 0.8600 0.8600 0.8533 0.8533 0.8467 0.8467 0.8400 0.8400 0.8333 0.8333 0.8267 0.8267 0.8200 0.8200 0.8100 0.8100 0.8000 0.8000 0.7900 0.7900 0.7800 0.7800 0.7700 0.7700 0.7667 0.7667 0.7633 0.7633 0.7600 0.7600 0.7567 0.7567 0.7533 0.7533 0.7500 0.7500 0.7467 0.7467 0.7433 0.7433 0.7400 0.7400 0.7367 0.7367 0.7333 0.7333 0.7300 0.7300 0.7267 0.7267 0.7233 0.7233 0.7200";
            string [] facarray = fac.Split(' ');

            for (int i = facarray.Length - 1; i >= 0; i--)
            {

                list.Add(Convert.ToDecimal(facarray[i]));
            }


            return list;
        }

        List<decimal> GetList2()
        {
            List<decimal> list = new List<decimal>();

            string fac ="6.4990 5.1820 4.5420 3.9020 3.5845 3.2670 2.9240 2.5810 2.4195 2.2580 2.0965 1.9350 1.7775 1.6200 1.5195 1.4190 1.3520 1.2850 1.2517 1.2183 1.1850 1.1543 1.1237 1.0930 1.0620 1.0310 1.0000 0.9723 0.9447 0.9170 0.9170 0.9101 0.9101 0.9031 0.9031 0.8962 0.8962 0.8893 0.8893 0.8823 0.8823 0.8754 0.8754 0.8685 0.8685 0.8617 0.8617 0.8550 0.8550 0.8483 0.8483 0.8417 0.8417 0.8350 0.8350 0.8283 0.8283 0.8217 0.8217 0.8150 0.8150 0.8056 0.8056 0.7962 0.7962 0.7868 0.7868 0.7774 0.7774 0.7680 0.7680 0.7645 0.7645 0.7611 0.7611 0.7576 0.7576 0.7541 0.7541 0.7507 0.7507 0.7472 0.7472 0.7437 0.7437 0.7403 0.7403 0.7368 0.7368 0.7333 0.7333 0.7299 0.7299 0.7264 0.7264 0.7229 0.7229 0.7195 0.7195 0.7160";
            string[] facarray = fac.Split(' ');

            for (int i = facarray.Length - 1; i >= 0; i--)
            {

                list.Add(Convert.ToDecimal(facarray[i]));
            }

            return list;
        }





        private static void CloneDirectory(string root, string dest)
        {
            foreach (var directory in Directory.GetDirectories(root))
            {
                //Get the path of the new directory
                var newDirectory = Path.Combine(dest, Path.GetFileName(directory));
                //Create the directory if it doesn't already exist
                Directory.CreateDirectory(newDirectory);
                //Recursively clone the directory
                CloneDirectory(directory, newDirectory);
            }

            foreach (var file in Directory.GetFiles(root))
            {
                File.Copy(file, Path.Combine(dest, Path.GetFileName(file)));
            }
        }


    }
}
