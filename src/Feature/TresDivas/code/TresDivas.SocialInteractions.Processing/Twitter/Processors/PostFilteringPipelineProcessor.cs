using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Sitecore.Tracking.Processing.Abstractions.Pipelines;

namespace TresDivas.SocialInteractions.Processing.Twitter.Processors
{
    public class PostFilteringPipelineProcessor : Processor
    {
        public PostFilteringPipelineProcessor(ILogger<Processor> logger) : base(logger)
        {
        }

        public override Task<PipelineArgs> RunAsync(PipelineArgs arg)
        {
            Logger.LogInformation("Tres Divas Twitter Interactions PostFilteringPipelineProcessor: " + arg.ProcessingResult.Interaction.Interaction.ChannelId);
            return Task.FromResult(arg);
        }
    }
}
