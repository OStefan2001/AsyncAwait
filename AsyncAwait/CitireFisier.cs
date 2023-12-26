using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AsyncAwait
{
    public class CitireFisier
    {
        public static async Task<string[]> FRead(string filePath, System.Threading.CancellationToken token)
        {
            try
            {
                if (File.Exists(filePath)) // Verificăm dacă fișierul există
                {
                    using (StreamReader reader = new StreamReader(filePath))
                    {
                        List<string> linii = new List<string>();
                        string linie;

                        while ((linie = await reader.ReadLineAsync()) != null)
                        {
                            linii.Add(linie);
                        }

                        return linii.ToArray();
                    }
                }
                else
                {
                    MessageBox.Show("Fișierul nu există.", "Eroare", MessageBoxButton.OK, MessageBoxImage.Error);
                    return null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Eroare la citirea fișierului: {ex.Message}", "Eroare", MessageBoxButton.OK, MessageBoxImage.Error);
                return null;
            }
        }

    }

}
