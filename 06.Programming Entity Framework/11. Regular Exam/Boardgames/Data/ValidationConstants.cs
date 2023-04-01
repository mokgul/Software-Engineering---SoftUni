namespace Boardgames.Data;

public class ValidationConstants
{
    //Creator
    public const int CreatorFirstNameLengthMin = 2;
    public const int CreatorFirstNameLengthMax = 7;
    public const int CreatorLastNameLengthMin = 2;
    public const int CreatorLastNameLengthMax = 7;

    //Boardgame
    public const int BoardgameNameLengthMin = 10;
    public const int BoardgameNameLengthMax = 20;
    public const double BoardgameRatingValueMin = 1.0;
    public const double BoardgameRatingValueMax = 10.0;
    public const int BoardgameYearMin = 2018;
    public const int BoardgameYearMax = 2023;

    //Seller
    public const int SellerNameLengthMin = 5;
    public const int SellerNameLengthMax = 20;
    public const int SellerAddressLengthMin = 2;
    public const int SellerAddressLengthMax = 30;
    public const string SellerWebsiteValidation = @"www.[A-Za-z\d-]+.com";
}