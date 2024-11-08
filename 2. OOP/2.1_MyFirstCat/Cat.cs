namespace MyFirstCat
{
    public class Cat
    {
        private string? _Color = null;
        private DateTime? _Birthdate = null;

        public string Color {
            get { return _Color; }
            set {
                if (_Color == value) return;
                _Color = value;
            };
        }

    }
}