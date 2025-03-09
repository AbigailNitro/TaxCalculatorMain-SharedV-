using System.Reflection.Metadata;

namespace TaxCalculatorMain2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        List<string> Slice = new List<String>();
        List<string> MinIncome = new List<String>();
        List<string> MaxIncome = new List<String>();
        List<string> MinTax = new List<String>();
        List<string> TaxRate = new List<String>();

        List<string> EmpID = new List<String>();
        List<string> EmpInc = new List<String>();

        public void taxScheduleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //found this code using https://learn.microsoft.com/en-us/dotnet/api/system.windows.forms.openfiledialog?view=windowsdesktop-9.0

            //define variables
            var filePath = string.Empty;

            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.InitialDirectory = "c:\\";
                ofd.Filter = "csv files (*.csv)|*.csv|All files (*.*)|*.*";
                ofd.FilterIndex = 2;
                ofd.RestoreDirectory = true;


                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    filePath = ofd.FileName;

                    var filestream = ofd.OpenFile();

                    using (StreamReader reader = new StreamReader(filestream))
                    {
                        //skip the first line (unneeded)
                        reader.ReadLine();

                        //loop to read file and put it into lists that represent columns
                        while (!reader.EndOfStream)
                        {
                            var Line = reader.ReadLine();
                            var Values = Line.Split(',');


                            Slice.Add(Values[0]);
                            MinIncome.Add(Values[1]);
                            MaxIncome.Add(Values[2]);
                            MinTax.Add(Values[3]);
                            TaxRate.Add(Values[4]);
                            

                            //Yeah so i tried to fix the unusual null value that comes with reading
                            //the csv, (specifically with minimum income for slice 1) and I cant fix it
                            //I cant insert another value on top of it and i cant stop it from being added to the arrays

                            //if (Values[1] == "")
                            //{
                                //MessageBox.Show("DUDE");
                            //}

                            //if (MinIncome.Count == 3)
                            //{
                                //string temp = MinIncome[2];
                                //MinIncome.Insert(1, Convert.ToString(0));
                                //MinIncome.Insert(2, temp);
                            //}


                        }

                        filestream.Close();
                    }
                }
            }




        }

        private void employeeIncomeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //found this code using https://learn.microsoft.com/en-us/dotnet/api/system.windows.forms.openfiledialog?view=windowsdesktop-9.0

            //define variables
            var filePath = string.Empty;

            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.InitialDirectory = "c:\\";
                ofd.Filter = "csv files (*.csv)|*.csv|All files (*.*)|*.*";
                ofd.FilterIndex = 2;
                ofd.RestoreDirectory = true;
                try
                {
                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        filePath = ofd.FileName;

                        var filestream = ofd.OpenFile();

                        using (StreamReader reader = new StreamReader(filestream))
                        {
                            //skip the first line (unneeded)
                            reader.ReadLine();

                            //loop to read file and put it into lists that represent columns
                            while (!reader.EndOfStream)
                            {
                                var Line = reader.ReadLine();
                                var Values = Line.Split(',');

                                EmpID.Add(Values[0]);
                                EmpInc.Add(Values[1]);

                            }

                            filestream.Close();
                        }
                    }
                }
                //these are unlikely to do much but theyre from the book and here nontheless
                catch (FileNotFoundException)
                {
                    MessageBox.Show(filePath + " not found.", "File not found");
                }
                catch (IOException ex)
                {
                    MessageBox.Show(ex.Message, "IOException");
                }
            }
        }

        private void btnCalc_Click(object sender, EventArgs e)
        {
            //code from https://csharpforums.net/threads/convert-a-list-object-to-a-string-2d-array.5865/

            //DEFINE ARRAY
            string[,] TaxSchedule = new string[Slice.Count, 5];

            //loop to convert lists to array, 
            for (int i = 0; i < Slice.Count; i++)
            {
                TaxSchedule[i, 0] = Slice[0 + i];
                TaxSchedule[i, 1] = MinIncome[0 + i];
                TaxSchedule[i, 2] = MaxIncome[0 + i];
                TaxSchedule[i, 3] = MinTax[0 + i];
                TaxSchedule[i, 4] = TaxRate[0 + i];
            }
            //Array that can have its info recalled via "TaxSchedule[yvalue,xvalue]"
            //to get a value, look at the provided csv from the homework. to get the
            //y value, get the line number and subtract 2 (one because we left out
            //the names and another because arrays start with position 0)
            //to get the x value, just get the column number (starting from 0
            //[so from left to right it would be 0,1,2,3,4])
            


            //code to view an aspect of the array for testing purposes, feel free to delete
            MessageBox.Show(TaxSchedule[2, 2]);
        }

        private void currentTaxScheduleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //DEFINE ARRAY
            string[,] TaxSchedule = new string[Slice.Count, 5];

            //loop to convert lists to array, 
            for (int i = 0; i < Slice.Count; i++)
            {
                TaxSchedule[i, 0] = Slice[0 + i];
                TaxSchedule[i, 1] = MinIncome[0 + i];
                TaxSchedule[i, 2] = MaxIncome[0 + i];
                TaxSchedule[i, 3] = MinTax[0 + i];
                TaxSchedule[i, 4] = TaxRate[0 + i];
            }
            //uncomment this code to print out 1 full slice from the array
            //int tempV = 1;
            //MessageBox.Show(TaxSchedule[tempV, 0] + ", " + TaxSchedule[tempV, 1] + ", " + TaxSchedule[tempV, 2] + ", " + TaxSchedule[tempV, 3] + ", " + TaxSchedule[tempV, 4]);

            
            string ToDisplay = string.Empty;
            for (int i = 0; i <= TaxSchedule.GetUpperBound(0); i++)
            {
                if (i == 0)
                {
                    ToDisplay += "Slice, MinIncome, MaxIncome, MinTax, TaxRate\n";
                    ToDisplay += (TaxSchedule[i, 0] + ", " + "0" + ", " + TaxSchedule[i, 2] + ", " + TaxSchedule[i, 3] + ", " + TaxSchedule[i, 4] + i + "\n");
                }
                else if (i == TaxSchedule.GetUpperBound(0))
                {
                    ToDisplay += (TaxSchedule[i, 0] + ", " + TaxSchedule[i, 1] + ", " + "inf" + ", " + TaxSchedule[i, 3] + ", " + TaxSchedule[i, 4] + i + "\n");
                }
                else
                {
                    ToDisplay += (TaxSchedule[i, 0] + ", " + TaxSchedule[i, 1] + ", " + TaxSchedule[i, 2] + ", " + TaxSchedule[i, 3] + ", " + TaxSchedule[i, 4] + i + "\n");
                }
            }

            MessageBox.Show(ToDisplay);
        }

        private void btnExit_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

