using System;
using System.Collections.Generic;
using System.Text;

namespace DuckHunt.Validators;

public class InputValidator(HashSet<string> validInputs)
{
    public bool ValidateInput(string? input)
    {
        if(string.IsNullOrWhiteSpace(input)) return false;

        return validInputs.TryGetValue(input.ToLower(), out _);
    }
}
