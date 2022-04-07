using MaterialSkin;
using MaterialSkin.Controls;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml;

namespace rokutroller
{
    public partial class Form1 : MaterialForm
    {
        private static readonly HttpClient client = new HttpClient();
        XmlDocument doc = new XmlDocument();
        public Form1()
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.Pink200, TextShade.WHITE);
        }
        
        async void keyPress(string button)
        {
            if (materialTextBox1.Text == "")
            {
                MessageBox.Show("Please enter a IP address.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // OK button
            var values = new Dictionary<string, string> { };

            var content = new FormUrlEncodedContent(values);

            await client.PostAsync("http://" + materialTextBox1.Text + ":8060/keypress/"+button, content);
        }

        async void openYt(string id)
        {
            if (materialTextBox1.Text == "")
            {
                MessageBox.Show("Please enter a IP address.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (materialTextBox2.Text == "")
            {
                MessageBox.Show("Please enter a YouTube video ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var values = new Dictionary<string, string> { };

            var content = new FormUrlEncodedContent(values);

            await client.PostAsync("http://" + materialTextBox1.Text + ":8060/launch/837?contentId=" + id, content);
        }
        async private void materialButton1_Click(object sender, EventArgs e)
        {
            if(materialTextBox1.Text == "")
            {
                MessageBox.Show("Please enter a IP address.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var responseString = await client.GetStringAsync("http://"+materialTextBox1.Text+":8060/query/device-info");
            MessageBox.Show(responseString);
        }

        private void materialButton3_Click(object sender, EventArgs e)
        {
            keyPress("Select");
        }

        private void materialButton4_Click(object sender, EventArgs e)
        {
            // UP button
            keyPress("Up");
        }

        private void materialButton6_Click(object sender, EventArgs e)
        {
            // Down button
            keyPress("Down");
        }

        private void materialButton2_Click(object sender, EventArgs e)
        {
            // Left button
            keyPress("Left");
        }

        private void materialButton5_Click(object sender, EventArgs e)
        {
            // Right button
            keyPress("Right");
        }

        private void materialButton9_Click(object sender, EventArgs e)
        {
            // Home button
            keyPress("Home");
        }

        private void materialButton10_Click(object sender, EventArgs e)
        {
            // Back button
            keyPress("Back");
        }

        private void materialButton7_Click(object sender, EventArgs e)
        {
            // Volume Up button
            keyPress("VolumeUp");
        }

        private void materialButton8_Click(object sender, EventArgs e)
        {
            // Volume Down button
            keyPress("VolumeDown");
        }

        private void materialButton11_Click(object sender, EventArgs e)
        {
            openYt(materialTextBox2.Text);
        }
    }
}