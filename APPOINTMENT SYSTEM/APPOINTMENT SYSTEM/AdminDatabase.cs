using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APPOINTMENT_SYSTEM
{
    public partial class AdminDatabase : Form
    {
        private SqlConnection con;
        public AdminDatabase()
        {
            con = new SqlConnection("Data Source=DESKTOP-LOU3UGG;Initial Catalog=FinalProject;Integrated Security=True");
            InitializeComponent();
        }

        private void AdminDatabase_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'finalProjectDataSet.appointment' table. You can move, or remove it, as needed.
            this.appointmentTableAdapter.Fill(this.finalProjectDataSet.appointment);

        }
    }
}
