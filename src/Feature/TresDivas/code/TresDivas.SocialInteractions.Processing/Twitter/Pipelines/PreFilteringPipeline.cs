using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Sitecore.Framework.Conditions;
using Sitecore.Tracking.Processing.Abstractions.Pipelines;

namespace TresDivas.SocialInteractions.Processing.Twitter.Pipelines
{
    public class PreFilteringPipeline : BasePreFilteringPipeline
    {
        public PreFilteringPipeline(ILogger<TrackingProcessingPipeline> logger, List<Processor> processors)
            : base(logger, processors)
        {
        }

        public async Task<PipelineArgs> RunAsync(PipelineArgs arg)
        {
            PreFilteringPipeline filteringPipeline = this;
            filteringPipeline.Logger.LogInformation(string.Format("Twitter.Tracking.Processing.ChannelManagement.Pipelines.PreFilteringPipeline Start: {0}", "Hetal was here!"), Array.Empty<object>());
            Condition.Requires(arg, nameof(arg)).IsNotNull();
            filteringPipeline.Logger.LogInformation(string.Format("Twitter.Tracking.Processing.ChannelManagement.Pipelines.PreFilteringPipeline Start: {0}", filteringPipeline.GetType().FullName), Array.Empty<object>());
            PipelineArgs pipelineArgs = await filteringPipeline.RunAsync(arg, CancellationToken.None).ConfigureAwait(false);
            filteringPipeline.Logger.LogInformation(string.Format("Twitter.Tracking.Processing.ChannelManagement.Pipelines.PreFilteringPipeline End: {0}", filteringPipeline.GetType().FullName), Array.Empty<object>());
            return pipelineArgs;
        }
    }
}
