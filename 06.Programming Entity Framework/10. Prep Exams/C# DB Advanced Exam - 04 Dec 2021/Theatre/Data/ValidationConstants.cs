namespace Theatre.Data;

public class ValidationConstants
{
    //Play
    public const int PlayTitleLengthMin = 4;
    public const int PlayTitleLengthMax = 50;
    public const double PlayRatingRangeMax = 10.0;
    public const int PlayDescriptionLengthMax = 700;
    public const int PlayScreenwriterNameMin = 4;
    public const int PlayScreenwriterNameMax = 30;

    //cast
    public const int CastNameLengthMin = 4;
    public const int CastNameLengthMax = 30;

    //Theater
    public const int TheaterNameLengthMin = 4;
    public const int TheaterNameLengthMax = 30;
    public const int TheaterNumberOfHallsMin = 1;
    public const int TheaterNumberOfHallsMax = 10;
    public const int TheaterDirectorNameLengthMin = 4;
    public const int TheaterDirectorNameLengthMax = 30;

    //Ticket
    public const double TicketPriceRangeMin = 1.00;
    public const double TicketPriceRangeMax = 100.00;
    public const int TicketRowNumberMin = 1;
    public const int TicketRowNumberMax = 10;
}