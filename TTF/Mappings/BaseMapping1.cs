﻿namespace TTF.Mappings
{
    public class BaseMapping1 : IMappingBase
    {
        public Input InData { get; private set; }

        public virtual string Name { get { return "Base Mapping A"; } }

        /// <summary>
        /// A && B && !C => X = S
        /// </summary>
        public virtual bool IsAcceptable { get { return InData.A && InData.B && !InData.C; } }

        public Output.XEnum X { get { return Output.XEnum.S; } }

        /// <summary>
        /// X = S => Y = D + (D * E / 100)
        /// </summary>
        public decimal Y { get { return InData.D + (InData.D * InData.E / 100); } }

        public BaseMapping1(Input input)
        {
            InData = input;
        }
    }
}
