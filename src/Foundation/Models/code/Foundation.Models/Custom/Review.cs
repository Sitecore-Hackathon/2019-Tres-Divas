namespace Foundation.Models
{
    public partial class Review : GlassBase, IReview
    {
        
        public virtual double? SentimentFromCognitive { get; set; }
        
    }
    
}