using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPGFDensity
{
    internal class SupportForms
    {


        public void ModuleIds(string RWFolder, string Rel, string PI, string EffDate)
        {
            string[] files = Directory.GetFiles(RWFolder, "moduleid.fil", SearchOption.AllDirectories);
            foreach (string file in files)
            {

                string FileNam = file;
                List<string> datalist = new List<string>();
                datalist = File.ReadAllLines(file).Where(x => x != "\u001a").Distinct().ToList();

                datalist[1] = EffDate;
                datalist[2] = Rel;
                datalist[4] = datalist[4].Replace(datalist[4].Substring(0, 5), PI);

                File.Delete(file);
                File.WriteAllLines(FileNam, datalist);

            }

        }


        public void RWxmls(string RWFolder, string Rel, string prevRel)
        {
            string[] files = Directory.GetFiles(RWFolder, "*.xml", SearchOption.AllDirectories);
            foreach (string file in files)
            {

                string FileName = file;
                List<string> datalist = new List<string>();
                List<string> XMLdatalist = new List<string>();
                datalist = File.ReadAllLines(file).Where(x => x != "\u001a").Distinct().ToList();

                foreach (var item in datalist)
                {
                    if (item.Contains(prevRel + "."))
                    {
                        string newitem = item.Replace(prevRel + ".", Rel + ".");
                        XMLdatalist.Add(newitem);
                    }
                    else
                    { XMLdatalist.Add(item); }

                }

                File.Delete(file);
                File.WriteAllLines(FileName, XMLdatalist);
                XMLdatalist.Clear();

            }

        }



    }
}
