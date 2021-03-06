﻿// IConverter.cs is a part of Autosys project in BDSA-2015. Created: 17, 11, 2015.
// Creators: Dennis Thinh Tan Nguyen, William Diedricsehn Marstrand, Thor Valentin Aakjær Olesen Nielsen, 
// Jacob Mullit Møiniche.

using System.Collections.Generic;
using ApplicationLogics.ProtocolManagement;


namespace ApplicationLogics.ExportManagement.Interfaces
{
    /// <summary>
    ///     Interface for Converter classes used by an ExportHandler.
    /// </summary>
    public interface IConverter
    {
        string Convert(Protocol protocol);
    }
}