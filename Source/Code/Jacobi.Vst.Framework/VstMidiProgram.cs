﻿namespace Jacobi.Vst.Framework
{
    using System;
    using Jacobi.Vst.Core;

    /// <summary>
    /// Contains information about a Midi Program.
    /// </summary>
    public class VstMidiProgram
    {
        private static readonly string[] KeyNames = { "C", "C#", "D", "D#", "E", "F", "F#", "G", "G#", "A", "A#", "B" };

        private string _name;
        /// <summary>
        /// Gets or sets the name of the Midi program.
        /// </summary>
        /// <remarks>The Name cannot exceed 63 characters.</remarks>
        public string Name
        {
            get { return _name; }
            set
            {
                Throw.IfArgumentTooLong(value, Core.Constants.MaxMidiNameLength, "Name");

                _name = value;
            }
        }

        /// <summary>
        /// Gets or sets the Midi Program Change message value.
        /// </summary>
        public byte ProgramChange { get; set; }
        
        /// <summary>
        /// Gets or sets the Most Significant Byte (Hi) value of the Midi Bank Select message.
        /// </summary>
        public byte BankSelectMsb { get; set; }
        
        /// <summary>
        /// Gets or sets the Least Significant Byte (Lo) value of the Midi Bank Select message.
        /// </summary>
        public byte BankSelectLsb { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="VstMidiCategory"/> instance this Midi program is part of.
        /// </summary>
        /// <remarks>Can be null.</remarks>
        public VstMidiCategory ParentCategory { get; set; }

        /// <summary>
        /// Retrieves the name of the specified <paramref name="keyNumber"/>.
        /// </summary>
        /// <param name="keyNumber">The Midi key number (note number).</param>
        /// <returns>Returns a string containing the note (C,C#,D -- A,A#,B) and an ocatve number starting at -2.</returns>
        public virtual string GetKeyName(int keyNumber)
        {
            int note = keyNumber % 12;
            int octave = keyNumber / 12;

            return KeyNames[note] + (octave - 2);
        }
    }
}
