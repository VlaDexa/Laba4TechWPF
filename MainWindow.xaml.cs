using System.Text;
using System.Windows;

namespace Laba4TechWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            const uint offset = 6;
            InputText.TextChanged += (one, two) =>
            {
                var code = new Ceasar(InputText.Text, offset);
                OutputText.Text = (string)code;
            };
        }
    }

    class Ceasar
    {
        private readonly uint _offset;
        private readonly string _text;

        public Ceasar(string text, uint offset)
        {
            _text = text;
            _offset = offset;
        }

        public static explicit operator string(Ceasar code)
        {
            var encoded = new StringBuilder(code._text.Length);
            foreach (char c in code._text)
            {
                var chr = c;
                for (var i = 0; i < code._offset; ++i)
                {
                    chr = chr.AdvanceByOne();
                }
                encoded.Append(chr);
            }
            return encoded.ToString();
        }

        public static implicit operator Ceasar(string text)
        {
            return new Ceasar(text, 5);
        }
    }

    public static class Extensions
    {
        public static char AdvanceByOne(this char input)
        {
            return input switch
            {
                'Я' => 'А',
                'я' => 'а',
                'е' => 'ё',
                'Е' => 'Ё',
                'ё' => 'ж',
                'Ё' => 'Ж',
                >= 'А' and <= 'я' => (char)(input + 1),
                _ => input,
            };
        }
    }
}
