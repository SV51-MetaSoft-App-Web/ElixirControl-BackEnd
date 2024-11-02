namespace ElixirControlPlatform.API.WinemakingProcess.Domain.Model.Entities;

public class Clarification
{
    public int Id { get; private set; }
    
    //========================== Clarification Information ==========================
    public int BatchId { get; private set; }
    public string ProductsUsed { get; private set; }
    public string ClarificationMethod { get; private set; }
    public DateTime? FiltrationDate { get; private set; }
    public double ClarityLevel { get; private set; }
    
    //------------------------- Clarification Date -------------------------
    public DateTime?  StartDate { get; private set; }
    public DateTime? EndDate { get; private set; }
    //======================== end Clarification Information ========================
    
    
    public Clarification()
    {
        this.BatchId = 0;
        this.ProductsUsed = string.Empty;
        this.ClarificationMethod = string.Empty;
        this.FiltrationDate = null;
        this.ClarityLevel = 0;
        this.StartDate = null;
        this.EndDate = null;
    }
    
    public Clarification(int batchId, string productsUsed, string clarificationMethod, string filtrationDate, double clarityLevel, string startDate, string endDate) : this()
    {
        BatchId = batchId;
        ProductsUsed = productsUsed;
        ClarificationMethod = clarificationMethod;
        FiltrationDate = ConvertToDate(filtrationDate);
        ClarityLevel = clarityLevel;
        StartDate = ConvertToDate(startDate);
        EndDate = ConvertToDate(endDate);
    }
    
    private static DateTime? ConvertToDate(string date)
    {
        if (DateTime.TryParseExact(date, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime parsedDate))
        {
            return parsedDate;
        }
        return null;
    }
    
    
}