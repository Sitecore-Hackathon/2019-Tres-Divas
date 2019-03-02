using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Sitecore.Framework.Conditions;
using Sitecore.Tracking.Processing.Abstractions.Pipelines;

namespace TresDivas.SocialInteractions.Processing.Twitter.Pipelines
{
    public class PostFilteringPipeline : BasePostFilteringPipeline
    {
        public PostFilteringPipeline(ILogger<TrackingProcessingPipeline> logger, List<Processor> processors) : base(logger, processors)
        {
        }

        public async Task<PipelineArgs> RunAsync(PipelineArgs arg)
        {
            PostFilteringPipeline filteringPipeline = this;
            Condition.Requires(arg, nameof(arg)).IsNotNull();
            filteringPipeline.Logger.LogDebug(string.Format("Pipeline Start: {0}", filteringPipeline.GetType().FullName), Array.Empty<object>());
            // ISSUE: reference to a compiler-generated method
            PipelineArgs pipelineArgs = await filteringPipeline.RunAsync(arg, CancellationToken.None).ConfigureAwait(false);
            filteringPipeline.Logger.LogDebug(string.Format("Pipeline End: {0}", filteringPipeline.GetType().FullName), Array.Empty<object>());
            return pipelineArgs;
        }
    }
}
