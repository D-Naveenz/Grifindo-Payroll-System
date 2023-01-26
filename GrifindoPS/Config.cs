using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GrifindoPS.Models;
using GrifindoPS.Exceptions;

namespace GrifindoPS
{
    public class Config
    {
        private static readonly Config _instance = new();
        private DateTime _cycleBegin;
        private DateTime _cycleEnd;

        private Config()
        {
            // For Debugging
            _cycleBegin = new(2023, 1, 1);
            _cycleEnd = new(2023, 1, 31);
        }

        public static Config Instance => _instance;

        public DateTime CycleBegin
        {
            get => _cycleBegin;
            set
            {
                if (value > _cycleEnd)
                {
                    throw new InvalidCycleException(value, _cycleEnd);
                }

                _cycleBegin = value;
            }
        }

        public DateTime CycleEnd
        {
            get => _cycleEnd;
            set
            {
                if (value < _cycleBegin)
                {
                    throw new InvalidCycleException(_cycleBegin, value);
                }

                _cycleEnd = value;
            }
        }

        public TimeSpan CycleRange()
        {
            return _cycleEnd.Subtract(_cycleBegin);
        }

        public float GvtTax { get; set; }
    }
}
