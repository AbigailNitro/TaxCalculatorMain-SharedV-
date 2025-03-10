using System.Diagnostics.Eventing.Reader;
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
        bool EmpLoaded = false;
        bool TaxLoaded = false;
        //I managed to convert the array conversion into it's own method
        //so we dont have to copy paste
        private string TaxSchedule(int vert, int hori)
        {
            //now unfortuantely the code sorts the array every time its recalled,
            //which would lead to increased hardware usage but i cant fix it without
            //first figuring out how to define the array outside the method using
            //slice count which iim not worried about now, just know that its something im aware of

            //code from https://csharpforums.net/threads/convert-a-list-object-to-a-string-2d-array.5865/

            string[,] testing = new string[Slice.Count, 5];

            for (int i = 0; i < Slice.Count; i++)
            {
                testing[i, 0] = Slice[0 + i];
                testing[i, 1] = MinIncome[0 + i];
                testing[i, 2] = MaxIncome[0 + i];
                testing[i, 3] = MinTax[0 + i];
                testing[i, 4] = TaxRate[0 + i];
                //Array that can have its info recalled via "TaxSchedule[yvalue,xvalue]"
                //to get a value, look at the provided csv from the homework. to get the
                //y value, get the line number and subtract 2 (one because we left out
                //the names and another because arrays start with position 0)
                //to get the x value, just get the column number (starting from 0
                //[so from left to right it would be 0,1,2,3,4])
            }
            return testing[vert, hori];
        }

        private string EmpTable(int vert, int hori)
        {
            string[,] testing = new string[EmpID.Count, 2];
            for (int i = 0; i < EmpID.Count; i++)
            {
                testing[i, 0] = EmpID[0 + i];
                testing[i, 1] = EmpInc[0 + i];
            }
            return testing[vert, hori];
        }


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
                        TaxLoaded = true;
                        filestream.Close();
                    }
                }
            }




        }

       

        private void btnCalc_Click(object sender, EventArgs e)
        {
            //really long code to call the tax table method and put it in the textbox
            txbTaxOwed.Text = Convert.ToString(CalculateTax(Convert.ToDecimal(txbTaxableIncome.Text)));
        }

        private void currentTaxScheduleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            string ToDisplay = string.Empty;
            for (int i = 0; i <= Slice.Count - 1; i++)
            {
                //while I cant fix the unusual null values from being inserted into the lists, i can cancel them out for this

                if (i == 0)
                {
                    ToDisplay += "Slice, MinIncome, MaxIncome, MinTax, TaxRate\n";
                    ToDisplay += (this.TaxSchedule(i, 0) + ", " + "0" + ", " + this.TaxSchedule(i, 2) + ", " + this.TaxSchedule(i, 3) + ", " + this.TaxSchedule(i, 4) + i + "\n");
                }
                else if (i == Slice.Count - 1)
                {
                    ToDisplay += (this.TaxSchedule(i, 0) + ", " + this.TaxSchedule(i, 1) + ", " + "inf" + ", " + this.TaxSchedule(i, 3) + ", " + this.TaxSchedule(i, 4) + i + "\n");
                }
                else
                {
                    ToDisplay += (this.TaxSchedule(i, 0) + ", " + this.TaxSchedule(i, 1) + ", " + this.TaxSchedule(i, 2) + ", " + this.TaxSchedule(i, 3) + ", " + this.TaxSchedule(i, 4) + i + "\n");
                }
            }

            MessageBox.Show(ToDisplay);
        }

        private void btnExit_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }





        //Code from ryan, had to revise so that it can input any value and make use of the assigned array
        // private decimal CalculateTax(decimal income)
        // {
        //    decimal tax = income switch
        //     {
        //         <= 11000 => income * 0.10m,
        //         <= 44725 => 1100 + (income - 11000) * 0.12m,
        //         <= 95375 => 5147 + (income - 44725) * 0.22m,
        //         <= 182100 => 16290 + (income - 95375) * 0.24m,
        //         <= 231250 => 37104 + (income - 182100) * 0.32m,
        //         <= 578125 => 52832 + (income - 231250) * 0.35m,
        //         _ => 174238.25m + (income - 578125) * 0.37m

        //     };
        //     return tax;

        //revised code
        //took me about 3 hours to finish this lol
        //ignore the commented code, those are the remains of my bugtesting
        private decimal CalculateTax(decimal income)
        {
            decimal tax = 0;
            if (TaxLoaded == false)
            {
                MessageBox.Show("Please load a tax schedule", "Tax Schedule Needed");
                return tax;
            }
            else
            {
                //MessageBox.Show("method started");

                for (int i = 0; i < Slice.Count; i++)
                {
                    //MessageBox.Show("loop started");
                    if (i == 0 && income < Convert.ToDecimal(this.TaxSchedule(0, 2)))
                    {
                        tax = (income - Convert.ToDecimal(this.TaxSchedule(0, 3))) * (Convert.ToDecimal(this.TaxSchedule(0, 4)) / 100m);

                        //MessageBox.Show("used if 1");
                        i = Slice.Count;
                    }
                    else if ((i == Slice.Count - 1) && income >= Convert.ToDecimal(this.TaxSchedule((Slice.Count - 1), 1)))
                    {
                        tax = (income - Convert.ToDecimal(this.TaxSchedule((Slice.Count - 1), 3))) * (Convert.ToDecimal(this.TaxSchedule((Slice.Count - 1), 4)) / 100m);

                        //MessageBox.Show("used if 2");
                        i = Slice.Count;
                    }
                    // a bunch of AND stuff because ii dont want random errors popping up
                    else if (i != 0 && income >= Convert.ToDecimal(this.TaxSchedule(i, 1)) && income < Convert.ToDecimal(this.TaxSchedule(i, 2)) && i != Convert.ToUInt32(Slice.Count - 1))
                    {
                        tax = (income - Convert.ToDecimal(this.TaxSchedule(i, 3))) * (Convert.ToDecimal(this.TaxSchedule(i, 4)) / 100m);

                        //MessageBox.Show("used if 3");
                        i = Slice.Count;
                    }
                    else
                    {
                        //MessageBox.Show("finished loop #" + i);
                    }



                }
                //MessageBox.Show(Convert.ToString(income));
                return tax;
            }
        }

        private void employeeTaxesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (EmpLoaded == false)
            {
                MessageBox.Show("Please load an employee roster", "Employee Roster Needed");
            }

            //code from ryan
            if (EmpID.Count == 0 || EmpInc.Count == 0)
            {
                MessageBox.Show("No employee data available to calculate taxes.");
                return;
            }

            //code from ryan
            if (EmpID.Count != EmpInc.Count)
            {
                MessageBox.Show("There is a mismatch between the number of employees and calculated taxes.");
                return;
            }

            //based on my previous code
            string ToDisplay = string.Empty;
            ToDisplay += "Employee ID, Employee Tax Owed \n";
            for (int i = 0; i < EmpInc.Count; i++)
            {
                ToDisplay += (EmpTable(i, 0) + ", " + this.CalculateTax(Convert.ToDecimal(EmpTable(i, 1))) + "\n");
            }

            MessageBox.Show(ToDisplay);
        }

       

        private void employeeIncomeToolStripMenuItem_Click_2(object sender, EventArgs e)
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

                            EmpLoaded = true;
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
    }
}

