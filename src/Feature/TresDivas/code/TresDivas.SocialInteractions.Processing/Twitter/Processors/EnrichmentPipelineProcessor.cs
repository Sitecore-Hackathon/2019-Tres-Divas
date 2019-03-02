using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Sitecore.Tracking.Processing.Abstractions.Pipelines;

namespace TresDivas.SocialInteractions.Processing.Twitter.Processors
{
    public class EnrichmentPipelineProcessor : Processor
    {
        public EnrichmentPipelineProcessor(ILogger<Processor> logger) : base(logger)
        {
        }

        public override Task<PipelineArgs> RunAsync(PipelineArgs arg)
        {
            // Are they verified buyers?
            // Build contact
            Logger.LogInformation("Tres Divas Twitter Interactions EnrichmentPipeline: " + arg.ProcessingResult.Interaction.Interaction.ChannelId);
            return Task.FromResult(arg);
        }
    }
}
