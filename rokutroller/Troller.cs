using MaterialSkin;
using MaterialSkin.Controls;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml;

namespace rokutroller
{
    public partial class Troller : MaterialForm
    {
        private static readonly HttpClient client = new();
        public Troller()
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.Pink200, TextShade.WHITE);
        }

        private async void ECPKeyPress(string button)
        {
            if (string.IsNullOrEmpty(materialTextBox1.Text))
            {
                MessageBox.Show("Please enter a IP address.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // OK button
            Dictionary<string, string> values = new();
            var content = new FormUrlEncodedContent(values);

            try
            {
                await client.PostAsync("http://" + materialTextBox1.Text + ":8060/keypress/" + button, content);
            }
            catch (Exception)
            {
                MessageBox.Show("The specified IP address was invalid.", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                client.Dispose();
            }
        }

        async void OpenYt(string id)
        {
            if (string.IsNullOrEmpty(materialTextBox1.Text))
            {
                MessageBox.Show("Please enter a IP address.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(materialTextBox2.Text))
            {
                MessageBox.Show("Please enter a YouTube video ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Dictionary<string, string> values = new();
            var content = new FormUrlEncodedContent(values);

            try
            {
                await client.PostAsync("http://" + materialTextBox1.Text + ":8060/launch/837?contentId=" + id, content);
            }
            catch (Exception)
            {
                MessageBox.Show("The specified IP address was invalid.", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                client.Dispose();
            }
        }
        async private void MaterialButton1_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(materialTextBox1.Text))
            {
                MessageBox.Show("Please enter a IP address.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var responseString = await client.GetStringAsync("http://"+materialTextBox1.Text+":8060/query/device-info");
            MessageBox.Show(responseString);
        }

        private void MaterialButton3_Click(object sender, EventArgs e)
        {
            ECPKeyPress("Select");
        }

        private void MaterialButton4_Click(object sender, EventArgs e)
        {
            // UP button
            ECPKeyPress("Up");
        }

        private void MaterialButton6_Click(object sender, EventArgs e)
        {
            // Down button
            ECPKeyPress("Down");
        }

        private void MaterialButton2_Click(object sender, EventArgs e)
        {
            // Left button
            ECPKeyPress("Left");
        }

        private void MaterialButton5_Click(object sender, EventArgs e)
        {
            // Right button
            ECPKeyPress("Right");
        }

        private void MaterialButton9_Click(object sender, EventArgs e)
        {
            // Home button
            ECPKeyPress("Home");
        }

        private void MaterialButton10_Click(object sender, EventArgs e)
        {
            // Back button
            ECPKeyPress("Back");
        }

        private void MaterialButton7_Click(object sender, EventArgs e)
        {
            // Volume Up button
            ECPKeyPress("VolumeUp");
        }

        private void MaterialButton8_Click(object sender, EventArgs e)
        {
            // Volume Down button
            ECPKeyPress("VolumeDown");
        }

        private void MaterialButton11_Click(object sender, EventArgs e)
        {
            OpenYt(materialTextBox2.Text);
        }
    }
}