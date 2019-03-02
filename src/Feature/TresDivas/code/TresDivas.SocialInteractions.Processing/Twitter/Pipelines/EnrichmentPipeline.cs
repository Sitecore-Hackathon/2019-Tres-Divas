using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Sitecore.Framework.Conditions;
using Sitecore.Tracking.Processing.Abstractions.Pipelines;

namespace TresDivas.SocialInteractions.Processing.Twitter.Pipelines
{
    public class EnrichmentPipeline : BaseEnrichmentPipeline
    {
        public EnrichmentPipeline(ILogger<TrackingProcessingPipeline> logger, List<Processor> processors) : base(logger, processors)
        {
        }

        public async Task<PipelineArgs> RunAsync(PipelineArgs arg)
        {
            EnrichmentPipeline enrichmentPipeline = this;
            Condition.Requires(arg, nameof(arg)).IsNotNull();
            enrichmentPipeline.Logger.LogDebug(string.Format("Pipeline Start: {0}", enrichmentPipeline.GetType().FullName), Array.Empty<object>());
            // ISSUE: reference to a compiler-generated method
            PipelineArgs pipelineArgs = await enrichmentPipeline.RunAsync(arg, CancellationToken.None).ConfigureAwait(false);
            enrichmentPipeline.Logger.LogDebug(string.Format("Pipeline End: {0}", enrichmentPipeline.GetType().FullName), Array.Empty<object>());
            return pipelineArgs;
        }

    }
}
