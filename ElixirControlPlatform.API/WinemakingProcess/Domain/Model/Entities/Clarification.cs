namespace ElixirControlPlatform.API.WinemakingProcess.Domain.Model.Entities;

public class Clarification
{
    public int Id { get; private set; }
    
    //========================== Clarification Information ==========================
    public int BatchId { get; private set; }
    public string ProductsUsed { get; private set; }
    public string ClarificationMethod { get; private set; }
    public string FiltrationDate { get; private set; }
    public double ClarityLevel { get; private set; }
    
    //------------------------- Clarification Date -------------------------
    public string StartDate { get; private set; }
    public string EndDate { get; private set; }
    //======================== end Clarification Information ========================
    
    
    public Clarification()
    {
        this.BatchId = 0;
        this.ProductsUsed = string.Empty;
        this.ClarificationMethod = string.Empty;
        this.FiltrationDate = string.Empty;
        this.ClarityLevel = 0;
        this.StartDate =  string.Empty;
        this.EndDate = string.Empty;
    }
    
    public Clarification(int batchId, string productsUsed, string clarificationMethod, string filtrationDate, double clarityLevel, string startDate, string endDate) : this()
    {
        BatchId = batchId;
        ProductsUsed = productsUsed;
        ClarificationMethod = clarificationMethod;
        FiltrationDate = filtrationDate;
        ClarityLevel = clarityLevel;
        StartDate = startDate;
        EndDate = endDate;
    }
    
    
    
}