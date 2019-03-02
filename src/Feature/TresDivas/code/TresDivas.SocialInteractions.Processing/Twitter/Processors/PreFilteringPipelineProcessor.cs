using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Sitecore.Tracking.Processing.Abstractions.Pipelines;

namespace TresDivas.SocialInteractions.Processing.Twitter.Processors
{
    public class PreFilteringPipelineProcessor : Processor
    {
        public PreFilteringPipelineProcessor(ILogger<Processor> logger) : base(logger)
        {
        }

        public override Task<PipelineArgs> RunAsync(PipelineArgs arg)
        {
            // Filter out hashtag
            // Age of the account
            // Retweets 
            // Number of followers 
            Logger.LogInformation("Tres Divas Twitter Interactions PreFilteringPipelineProcessor: " + arg.ProcessingResult.Interaction.Interaction.Id);
            var events = arg.ProcessingResult.Interaction.Interaction.Events;
            return Task.FromResult(arg);
        }
    }
}
