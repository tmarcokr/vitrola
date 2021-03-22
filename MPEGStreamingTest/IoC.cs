using MPEGCast.Core;
using MPEGInfo.Core;
using MPEGInfo.Core.Bitrate;
using MPEGInfo.Core.SamplingRate;
using MPEGInfo.Extension;
using System.Collections.Generic;
using bitrateMap = MPEGInfo.Core.Bitrate.Map;
using samplingRateMap = MPEGInfo.Core.SamplingRate.Map;

namespace MPEGStreamingTest
{
    public class IoC
    {
        public IceTcpClient IceCastTcpClient { get; private set; }

        public IoC()
        {
            #region "POOR MAN DI"

            var bitRateIndexMap = new List<IMapperIndex<BitrateIndexValue>>()
            {
                new bitrateMap.Index_0(),
                new bitrateMap.Index_01(),
                new bitrateMap.Index_02(),
                new bitrateMap.Index_03(),
                new bitrateMap.Index_04(),
                new bitrateMap.Index_05(),
                new bitrateMap.Index_06(),
                new bitrateMap.Index_07(),
                new bitrateMap.Index_08(),
                new bitrateMap.Index_09(),
                new bitrateMap.Index_10(),
                new bitrateMap.Index_11(),
                new bitrateMap.Index_12(),
                new bitrateMap.Index_13(),
                new bitrateMap.Index_14(),
                new bitrateMap.Index_15()
            };

            var SamplingRateIndexMap = new List<IMapperIndex<SamplingRateIndexValue>>()
            {
                new samplingRateMap.Index_0(),
                new samplingRateMap.Index_01(),
                new samplingRateMap.Index_02(),
                new samplingRateMap.Index_03()
            };

            var bitRateIndex = new BitrateIndex(bitRateIndexMap);
            var samplingRateIndex = new SamplingRateIndex(SamplingRateIndexMap);
            MPEGFrameExtension.Initialize(bitRateIndex, samplingRateIndex);

            var iceNetWorkHandler = new IceNetworkHandler("127.0.0.1", 8000);
            IceCastTcpClient = new IceTcpClient(iceNetWorkHandler, "thiko");

            #endregion
        }
    }
}