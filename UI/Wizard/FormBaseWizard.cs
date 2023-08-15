using Nekdu.UI;
using Nekdu.UI.Wizard;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nekdu
{
    public partial class FormBaseWizard : Form
    {
        Form[] frm = {  new FormSelectFiles(), 
                        new FormSelectCertificado(), 
                        new FormResult() };
        int top = -1;
        int count;

        public static UIProperties UIProps { get; internal set; }
        public void EnableNext(bool flag) {
            btnNext.Enabled = flag;
         }
        public void EnableBack(bool flag) { 
            btnBack.Enabled = flag;
        }
        public void VisibleBack(bool flag) {
            btnBack.Visible = flag;
        }
        public void VisibleNext(bool flag)
        {
            btnNext.Visible = flag;
        }

        public bool IsVisibleNext() { 
            return btnNext.Visible;
        }

        public bool IsVisibleBack() { 
            return btnBack.Visible;
        }
        //--
        public FormBaseWizard()
        {
            count = frm.Count();
            UIProps = new UIProperties();
            UIProps.PDFSrcFiles = new List<string>(); 
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
        }
        //--
        private void LoadNewForm()
        {
            frm[top].TopLevel = false;
            frm[top].AutoScroll = true;
            frm[top].Dock = DockStyle.Fill;
            this.pContent.Controls.Clear();
            this.pContent.Controls.Add(frm[top]);
            //---------
            ((IWizard)frm[top]).SetFormBase(this);
            ((IWizard)frm[top]).SetStatusButtons();
            frm[top].Show();
        }

        private void Back()
        {
            top--;
            if (top <= -1)
            {
                return;
            }
            else
            {
                btnBack.Enabled = true;
                btnNext.Enabled = true;
                LoadNewForm();
                if (top - 1 <= -1)
                {
                    btnBack.Enabled = false;
                }
            }

            if (top >= count)
            {
                btnNext.Enabled = false;
                btnNext.Visible = false; //IFR.
            }
        }
        private void Next()
        {

            top++;
            if (top >= count)
            {
                return;
            }
            else
            {
                btnBack.Enabled = true;
                btnNext.Enabled = true;
                LoadNewForm();
                if (top + 1 == count)
                {
                    btnNext.Enabled = false;
                }
            }

            if (top <= 0)
            {
                btnBack.Enabled = false;
                btnBack.Visible = false; //IFR.

            }
        }

        private void FormBaseWizard_Load(object sender, EventArgs e)
        {
            Next();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            Next();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Back();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
