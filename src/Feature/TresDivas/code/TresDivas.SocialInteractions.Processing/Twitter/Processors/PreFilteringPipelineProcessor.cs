using System.Linq;
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
            if (arg.ProcessingResult.Interaction != null && arg.ProcessingResult.Interaction.Interaction != null &&
                arg.ProcessingResult.Interaction.Interaction.Events.Count > 0)
            {
                foreach (var interactionEvent in arg.ProcessingResult.Interaction.Interaction.Events)
                {
                    if (interactionEvent.CustomValues != null && interactionEvent.CustomValues.Count > 0)
                    {
                        string s = string.Join(";", interactionEvent.CustomValues.Select(x => x.Key + "=" + x.Value).ToArray());
                        Logger.LogInformation("Custom Values Tres Divas Twitter Interactions PreFilteringPipelineProcessor: " + s);
                    }

                    Logger.LogInformation(" DefinitionId Tres Divas Twitter Interactions PreFilteringPipelineProcessor: " + interactionEvent.DefinitionId);
                }
            }
            var events = arg.ProcessingResult.Interaction.Interaction.Events;
            return Task.FromResult(arg);
        }
    }
}
