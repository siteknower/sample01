using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StnwService;

namespace StnwSampleCS02
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            string filename = "schema.xml";

            System.IO.FileStream stream =
                new System.IO.FileStream(filename, System.IO.FileMode.Open);

            dsCustomers.ReadXmlSchema(stream);

            DataSet tds = GetData();

            DataGridView1.DataSource = tds.Tables["Users"];

            foreach (DataGridViewColumn column in DataGridView1.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private DataSet GetData()
        {
            DataTable dt = dsCustomers.Tables["Users"];
            dt.Rows.Add("ABDEN", "Maria Weiss", "Berlin", "Germany");
            dt.Rows.Add("AXEIS", "Pedro Alvarez", "México D.F.", "Mexico");
            dt.Rows.Add("BENOI", "Anna Tóth", "Szeged", "Hungary");
            dt.Rows.Add("CAZLE", "Jan Eriksson", "Mannheim", "Sweden");
            dt.Rows.Add("DRFIS", "Giulia Donatelli", "Milano", "Italia");
            return dsCustomers;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            clsStnwClass tsi = new clsStnwClass();
            string preslAccountCode = "DEMO1";  // your account code
            string preslUserCode = "0000"; // yout user code

            tsi.preslAccountCode = preslAccountCode;
            tsi.preslUserCode = preslUserCode;
            tsi.dsRPT = dsCustomers;
            tsi.RPTDEST = 0;

            string rptPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "CustomerReport1.rpt");
            tsi.ReportFullName = rptPath;

            tsi.ShowForm();
        }
    }
}
