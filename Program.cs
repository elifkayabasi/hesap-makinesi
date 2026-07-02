// Program.cs
// Bu dosya, uygulamanın başlangıç noktasıdır (entry point).
// Windows Forms uygulamaları buradan başlar.

namespace HesapMakinesi;

static class Program
{
    /// <summary>
    /// Uygulamanın giriş noktası (Main metodu).
    /// </summary>
    [STAThread] // Windows Forms için gerekli thread modeli
    static void Main()
    {
        // Uygulama yapılandırmasını başlat (DPI ayarları vb.)
        ApplicationConfiguration.Initialize();

        // HesapMakinesiForm formunu oluştur ve çalıştır
        Application.Run(new HesapMakinesiForm());
    }
}
