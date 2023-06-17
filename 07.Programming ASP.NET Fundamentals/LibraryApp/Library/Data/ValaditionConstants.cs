namespace Library.Data
{
    public class ValaditionConstants
    {
        public class Book
        {
            public const int TitleMinLength = 10;
            public const int TitleMaxLength = 50;
            public const int AuthorMinLength = 5;
            public const int AuthorMaxLength = 50;
            public const int DescriptionMinLength = 5;
            public const int DescriptionMaxLength = 5000;
            public const string RatingMinValue = "0.00";
            public const string RatingMaxValue = "10.00";
        }

        public class Category
        {
            public const int NameMinLength = 5;
            public const int NameMaxLength = 50;
        }
    }
}
