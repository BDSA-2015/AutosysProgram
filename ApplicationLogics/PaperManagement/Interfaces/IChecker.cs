﻿// IChecker.cs is a part of Autosys project in BDSA-2015. Created: 17, 11, 2015.
// Creators: Dennis Thinh Tan Nguyen, William Diedricsehn Marstrand, Thor Valentin Aakjær Olesen Nielsen, 
// Jacob Mullit Møiniche.

namespace ApplicationLogics.PaperManagement.Interfaces
{
    internal interface IChecker
    {
        bool Validate(ITag tag);
    }
}