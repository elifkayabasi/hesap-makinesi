// HesapMakinesiForm.cs
// Bu dosya, hesap makinesinin tüm arayüz bileşenlerini (TextBox, Button, Label)
// ve bu bileşenlere bağlı iş mantığını (toplama, çıkarma vb.) içerir.

namespace HesapMakinesi;

/// <summary>
/// Hesap makinesi formu.
/// Form sınıfı, Windows Forms'un temel Form sınıfından türetilir.
/// </summary>
public class HesapMakinesiForm : Form
{
    // ─── Arayüz Bileşenleri (UI Controls) ───────────────────────────────────
    // private: Bu değişkenlere sadece bu sınıf içinden erişilir.

    private TextBox txtSayi1;   // Birinci sayıyı girecek alan
    private TextBox txtSayi2;   // İkinci sayıyı girecek alan

    private Button btnTopla;    // Toplama butonu
    private Button btnCikar;    // Çıkarma butonu
    private Button btnCarp;     // Çarpma butonu
    private Button btnBol;      // Bölme butonu

    private Label lblSonuc;     // Sonucu gösterecek etiket

    // ─── Yapıcı Metot (Constructor) ─────────────────────────────────────────

    /// <summary>
    /// Form oluşturulduğunda çağrılır.
    /// Tüm bileşenler burada tanımlanır ve forma eklenir.
    /// </summary>
    public HesapMakinesiForm()
    {
        // Arayüzü kur
        ArayuзuHazirla();
    }

    // ─── Arayüz Kurulum Metodu ──────────────────────────────────────────────

    /// <summary>
    /// Tüm kontrolleri (bileşenleri) oluşturur ve forma ekler.
    /// Boyut, renk, konum gibi görsel ayarlar burada yapılır.
    /// </summary>
    private void ArayuзuHazirla()
    {
        // ── Form genel ayarları ──
        this.Text = "Hesap Makinesi";       // Başlık çubuğu yazısı
        this.Size = new Size(400, 380);     // Form genişliği ve yüksekliği (piksel)
        this.StartPosition = FormStartPosition.CenterScreen; // Ekranın ortasında aç
        this.FormBorderStyle = FormBorderStyle.FixedSingle;  // Yeniden boyutlandırma kapalı
        this.MaximizeBox = false;           // Büyütme düğmesini devre dışı bırak
        this.BackColor = Color.FromArgb(240, 240, 245); // Açık gri-mavi arka plan

        // ── Etiket: "Birinci Sayı" ──
        Label lblSayi1 = new Label();
        lblSayi1.Text = "Birinci Sayı:";
        lblSayi1.Location = new Point(30, 30);
        lblSayi1.Size = new Size(100, 25);
        lblSayi1.Font = new Font("Segoe UI", 10);

        // ── TextBox: Birinci sayı girişi ──
        txtSayi1 = new TextBox();
        txtSayi1.Location = new Point(150, 27);
        txtSayi1.Size = new Size(200, 30);
        txtSayi1.Font = new Font("Segoe UI", 11);
        txtSayi1.TextAlign = HorizontalAlignment.Right; // Sayıyı sağa yasla

        // ── Etiket: "İkinci Sayı" ──
        Label lblSayi2 = new Label();
        lblSayi2.Text = "İkinci Sayı:";
        lblSayi2.Location = new Point(30, 80);
        lblSayi2.Size = new Size(100, 25);
        lblSayi2.Font = new Font("Segoe UI", 10);

        // ── TextBox: İkinci sayı girişi ──
        txtSayi2 = new TextBox();
        txtSayi2.Location = new Point(150, 77);
        txtSayi2.Size = new Size(200, 30);
        txtSayi2.Font = new Font("Segoe UI", 11);
        txtSayi2.TextAlign = HorizontalAlignment.Right;

        // ── Buton: Toplama ──
        btnTopla = new Button();
        btnTopla.Text = "Topla  ( + )";
        btnTopla.Location = new Point(30, 140);
        btnTopla.Size = new Size(155, 45);
        btnTopla.Font = new Font("Segoe UI", 10, FontStyle.Bold);
        btnTopla.BackColor = Color.FromArgb(52, 152, 219);  // Mavi
        btnTopla.ForeColor = Color.White;
        btnTopla.FlatStyle = FlatStyle.Flat;
        btnTopla.FlatAppearance.BorderSize = 0;
        btnTopla.Cursor = Cursors.Hand;
        // Butona tıklandığında hangi metot çalışacak? → Click olayı
        btnTopla.Click += new EventHandler(BtnTopla_Click);

        // ── Buton: Çıkarma ──
        btnCikar = new Button();
        btnCikar.Text = "Çıkar  ( - )";
        btnCikar.Location = new Point(215, 140);
        btnCikar.Size = new Size(155, 45);
        btnCikar.Font = new Font("Segoe UI", 10, FontStyle.Bold);
        btnCikar.BackColor = Color.FromArgb(231, 76, 60);   // Kırmızı
        btnCikar.ForeColor = Color.White;
        btnCikar.FlatStyle = FlatStyle.Flat;
        btnCikar.FlatAppearance.BorderSize = 0;
        btnCikar.Cursor = Cursors.Hand;
        btnCikar.Click += new EventHandler(BtnCikar_Click);

        // ── Buton: Çarpma ──
        btnCarp = new Button();
        btnCarp.Text = "Çarp  ( × )";
        btnCarp.Location = new Point(30, 200);
        btnCarp.Size = new Size(155, 45);
        btnCarp.Font = new Font("Segoe UI", 10, FontStyle.Bold);
        btnCarp.BackColor = Color.FromArgb(39, 174, 96);    // Yeşil
        btnCarp.ForeColor = Color.White;
        btnCarp.FlatStyle = FlatStyle.Flat;
        btnCarp.FlatAppearance.BorderSize = 0;
        btnCarp.Cursor = Cursors.Hand;
        btnCarp.Click += new EventHandler(BtnCarp_Click);

        // ── Buton: Bölme ──
        btnBol = new Button();
        btnBol.Text = "Böl  ( ÷ )";
        btnBol.Location = new Point(215, 200);
        btnBol.Size = new Size(155, 45);
        btnBol.Font = new Font("Segoe UI", 10, FontStyle.Bold);
        btnBol.BackColor = Color.FromArgb(142, 68, 173);    // Mor
        btnBol.ForeColor = Color.White;
        btnBol.FlatStyle = FlatStyle.Flat;
        btnBol.FlatAppearance.BorderSize = 0;
        btnBol.Cursor = Cursors.Hand;
        btnBol.Click += new EventHandler(BtnBol_Click);

        // ── Ayraç çizgisi (Panel ile simüle) ──
        Panel pnlCizgi = new Panel();
        pnlCizgi.Location = new Point(30, 265);
        pnlCizgi.Size = new Size(340, 2);
        pnlCizgi.BackColor = Color.FromArgb(180, 180, 200);

        // ── Sonuç etiketi ──
        lblSonuc = new Label();
        lblSonuc.Text = "Sonuç: —";
        lblSonuc.Location = new Point(30, 280);
        lblSonuc.Size = new Size(340, 50);
        lblSonuc.Font = new Font("Segoe UI", 13, FontStyle.Bold);
        lblSonuc.ForeColor = Color.FromArgb(44, 62, 80);    // Koyu lacivert
        lblSonuc.TextAlign = ContentAlignment.MiddleCenter;
        lblSonuc.BorderStyle = BorderStyle.FixedSingle;
        lblSonuc.BackColor = Color.White;

        // ── Tüm bileşenleri forma ekle ──
        this.Controls.AddRange(new Control[]
        {
            lblSayi1, txtSayi1,
            lblSayi2, txtSayi2,
            btnTopla, btnCikar,
            btnCarp,  btnBol,
            pnlCizgi, lblSonuc
        });
    }

    // ─── Yardımcı Metot: Sayıları Oku ve Doğrula ────────────────────────────

    /// <summary>
    /// İki TextBox'taki değerleri double olarak okur.
    /// Geçersiz değer varsa false döndürür ve hata mesajı gösterir.
    /// </summary>
    /// <param name="sayi1">Birinci sayı (out parametresi)</param>
    /// <param name="sayi2">İkinci sayı (out parametresi)</param>
    /// <returns>Her iki değer de geçerliyse true, değilse false</returns>
    private bool SayilariOku(out double sayi1, out double sayi2)
    {
        // out parametrelerini başlangıçta sıfırla
        sayi1 = 0;
        sayi2 = 0;

        // TryParse: Metni sayıya çevirmeye çalışır.
        // Başarısız olursa false döner (exception fırlatmaz).
        if (!double.TryParse(txtSayi1.Text, out sayi1))
        {
            // Hata mesajı kutusu göster
            MessageBox.Show(
                "Birinci alana geçerli bir sayı giriniz!",
                "Geçersiz Giriş",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            );
            txtSayi1.Focus(); // Hatalı alana odaklan
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

        return true; // Her iki sayı da geçerli
    }

    // ─── Sonucu Göster ──────────────────────────────────────────────────────

    /// <summary>
    /// Hesaplama sonucunu Label'da gösterir.
    /// G6 formatı: gereksiz sıfırları kaldırır (örn. 3.000000 → 3)
    /// </summary>
    private void SonucuGoster(string islemSembolu, double sayi1, double sayi2, double sonuc)
    {
        lblSonuc.Text = $"{sayi1:G6}  {islemSembolu}  {sayi2:G6}  =  {sonuc:G6}";
        lblSonuc.ForeColor = Color.FromArgb(44, 62, 80); // Normal renk
    }

    // ─── Buton Click Olayları ────────────────────────────────────────────────

    /// <summary>
    /// "Topla" butonuna tıklandığında çalışır.
    /// </summary>
    private void BtnTopla_Click(object? sender, EventArgs e)
    {
        // Sayıları oku; geçersizse metodu burada bitir
        if (!SayilariOku(out double sayi1, out double sayi2))
            return;

        double sonuc = sayi1 + sayi2;
        SonucuGoster("+", sayi1, sayi2, sonuc);
    }

    /// <summary>
    /// "Çıkar" butonuna tıklandığında çalışır.
    /// </summary>
    private void BtnCikar_Click(object? sender, EventArgs e)
    {
        if (!SayilariOku(out double sayi1, out double sayi2))
            return;

        double sonuc = sayi1 - sayi2;
        SonucuGoster("-", sayi1, sayi2, sonuc);
    }

    /// <summary>
    /// "Çarp" butonuna tıklandığında çalışır.
    /// </summary>
    private void BtnCarp_Click(object? sender, EventArgs e)
    {
        if (!SayilariOku(out double sayi1, out double sayi2))
            return;

        double sonuc = sayi1 * sayi2;
        SonucuGoster("×", sayi1, sayi2, sonuc);
    }

    /// <summary>
    /// "Böl" butonuna tıklandığında çalışır.
    /// Sıfıra bölme kontrolü yapılır.
    /// </summary>
    private void BtnBol_Click(object? sender, EventArgs e)
    {
        if (!SayilariOku(out double sayi1, out double sayi2))
            return;

        // ── Sıfıra bölme kontrolü ──
        if (sayi2 == 0)
        {
            MessageBox.Show(
                "Bir sayı sıfıra bölünemez!",
                "Matematiksel Hata",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            );
            // Sonuç etiketinde de uyarı göster
            lblSonuc.Text = "⚠ Sıfıra bölme hatası!";
            lblSonuc.ForeColor = Color.Red;
            return;
        }

        double sonuc = sayi1 / sayi2;
        SonucuGoster("÷", sayi1, sayi2, sonuc);
    }
}
