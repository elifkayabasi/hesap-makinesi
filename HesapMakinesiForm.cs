namespace HesapMakinesi;

public class HesapMakinesiForm : Form
{
    private TextBox txtSayi1;
    private TextBox txtSayi2;

    private Button btnTopla;
    private Button btnCikar;
    private Button btnCarp;
    private Button btnBol;

    private Label lblSonuc;

    public HesapMakinesiForm()
    {
        ArayuzuHazirla();
    }

    private void ArayuzuHazirla()
    {
        this.Text = "Hesap Makinesi";
        this.Size = new Size(400, 380);
        this.StartPosition = FormStartPosition.CenterScreen;
        this.FormBorderStyle = FormBorderStyle.FixedSingle;
        this.MaximizeBox = false;
        this.BackColor = Color.FromArgb(240, 240, 245);

        Label lblSayi1 = new Label();
        lblSayi1.Text = "Birinci Sayı:";
        lblSayi1.Location = new Point(30, 30);
        lblSayi1.Size = new Size(100, 25);
        lblSayi1.Font = new Font("Segoe UI", 10);

        txtSayi1 = new TextBox();
        txtSayi1.Location = new Point(150, 27);
        txtSayi1.Size = new Size(200, 30);
        txtSayi1.Font = new Font("Segoe UI", 11);
        txtSayi1.TextAlign = HorizontalAlignment.Right;

        Label lblSayi2 = new Label();
        lblSayi2.Text = "İkinci Sayı:";
        lblSayi2.Location = new Point(30, 80);
        lblSayi2.Size = new Size(100, 25);
        lblSayi2.Font = new Font("Segoe UI", 10);

        txtSayi2 = new TextBox();
        txtSayi2.Location = new Point(150, 77);
        txtSayi2.Size = new Size(200, 30);
        txtSayi2.Font = new Font("Segoe UI", 11);
        txtSayi2.TextAlign = HorizontalAlignment.Right;

        btnTopla = new Button();
        btnTopla.Text = "Topla  ( + )";
        btnTopla.Location = new Point(30, 140);
        btnTopla.Size = new Size(155, 45);
        btnTopla.Font = new Font("Segoe UI", 10, FontStyle.Bold);
        btnTopla.BackColor = Color.FromArgb(52, 152, 219);
        btnTopla.ForeColor = Color.White;
        btnTopla.FlatStyle = FlatStyle.Flat;
        btnTopla.FlatAppearance.BorderSize = 0;
        btnTopla.Cursor = Cursors.Hand;
        btnTopla.Click += new EventHandler(BtnTopla_Click);

        btnCikar = new Button();
        btnCikar.Text = "Çıkar  ( - )";
        btnCikar.Location = new Point(215, 140);
        btnCikar.Size = new Size(155, 45);
        btnCikar.Font = new Font("Segoe UI", 10, FontStyle.Bold);
        btnCikar.BackColor = Color.FromArgb(231, 76, 60);
        btnCikar.ForeColor = Color.White;
        btnCikar.FlatStyle = FlatStyle.Flat;
        btnCikar.FlatAppearance.BorderSize = 0;
        btnCikar.Cursor = Cursors.Hand;
        btnCikar.Click += new EventHandler(BtnCikar_Click);

        btnCarp = new Button();
        btnCarp.Text = "Çarp  ( × )";
        btnCarp.Location = new Point(30, 200);
        btnCarp.Size = new Size(155, 45);
        btnCarp.Font = new Font("Segoe UI", 10, FontStyle.Bold);
        btnCarp.BackColor = Color.FromArgb(39, 174, 96);
        btnCarp.ForeColor = Color.White;
        btnCarp.FlatStyle = FlatStyle.Flat;
        btnCarp.FlatAppearance.BorderSize = 0;
        btnCarp.Cursor = Cursors.Hand;
        btnCarp.Click += new EventHandler(BtnCarp_Click);

        btnBol = new Button();
        btnBol.Text = "Böl  ( ÷ )";
        btnBol.Location = new Point(215, 200);
        btnBol.Size = new Size(155, 45);
        btnBol.Font = new Font("Segoe UI", 10, FontStyle.Bold);
        btnBol.BackColor = Color.FromArgb(142, 68, 173);
        btnBol.ForeColor = Color.White;
        btnBol.FlatStyle = FlatStyle.Flat;
        btnBol.FlatAppearance.BorderSize = 0;
        btnBol.Cursor = Cursors.Hand;
        btnBol.Click += new EventHandler(BtnBol_Click);

        Panel pnlCizgi = new Panel();
        pnlCizgi.Location = new Point(30, 265);
        pnlCizgi.Size = new Size(340, 2);
        pnlCizgi.BackColor = Color.FromArgb(180, 180, 200);

        lblSonuc = new Label();
        lblSonuc.Text = "Sonuç: —";
        lblSonuc.Location = new Point(30, 280);
        lblSonuc.Size = new Size(340, 50);
        lblSonuc.Font = new Font("Segoe UI", 13, FontStyle.Bold);
        lblSonuc.ForeColor = Color.FromArgb(44, 62, 80);
        lblSonuc.TextAlign = ContentAlignment.MiddleCenter;
        lblSonuc.BorderStyle = BorderStyle.FixedSingle;
        lblSonuc.BackColor = Color.White;

        this.Controls.AddRange(new Control[]
        {
            lblSayi1, txtSayi1,
            lblSayi2, txtSayi2,
            btnTopla, btnCikar,
            btnCarp,  btnBol,
            pnlCizgi, lblSonuc
        });
    }

    private bool SayilariOku(out double sayi1, out double sayi2)
    {
        sayi1 = 0;
        sayi2 = 0;

        if (!double.TryParse(txtSayi1.Text, out sayi1))
        {
            MessageBox.Show(
                "Birinci alana geçerli bir sayı giriniz!",
                "Geçersiz Giriş",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            );
            txtSayi1.Focus();
            return false;
        }

        if (!double.TryParse(txtSayi2.Text, out sayi2))
        {
            MessageBox.Show(
                "İkinci alana geçerli bir sayı giriniz!",
                "Geçersiz Giriş",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            );
            txtSayi2.Focus();
            return false;
        }

        return true;
    }

    private void SonucuGoster(string islemSembolu, double sayi1, double sayi2, double sonuc)
    {
        lblSonuc.Text = $"{sayi1:G6}  {islemSembolu}  {sayi2:G6}  =  {sonuc:G6}";
        lblSonuc.ForeColor = Color.FromArgb(44, 62, 80);
    }

    private void BtnTopla_Click(object? sender, EventArgs e)
    {
        if (!SayilariOku(out double sayi1, out double sayi2))
            return;

        double sonuc = sayi1 + sayi2;
        SonucuGoster("+", sayi1, sayi2, sonuc);
    }

    private void BtnCikar_Click(object? sender, EventArgs e)
    {
        if (!SayilariOku(out double sayi1, out double sayi2))
            return;

        double sonuc = sayi1 - sayi2;
        SonucuGoster("-", sayi1, sayi2, sonuc);
    }

    private void BtnCarp_Click(object? sender, EventArgs e)
    {
        if (!SayilariOku(out double sayi1, out double sayi2))
            return;

        double sonuc = sayi1 * sayi2;
        SonucuGoster("×", sayi1, sayi2, sonuc);
    }

    private void BtnBol_Click(object? sender, EventArgs e)
    {
        if (!SayilariOku(out double sayi1, out double sayi2))
            return;

        if (sayi2 == 0)
        {
            MessageBox.Show(
                "Bir sayı sıfıra bölünemez!",
                "Matematiksel Hata",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            );
            lblSonuc.Text = "⚠ Sıfıra bölme hatası!";
            lblSonuc.ForeColor = Color.Red;
            return;
        }

        double sonuc = sayi1 / sayi2;
        SonucuGoster("÷", sayi1, sayi2, sonuc);
    }
}
