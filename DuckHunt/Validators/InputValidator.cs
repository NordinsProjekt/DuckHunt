using System;
using System.Collections.Generic;
using System.Text;

namespace DuckHunt.Validators;

public class InputValidator(HashSet<string> validInputs)
{
    public bool ValidateInput(string? input)
    {
        return !string.IsNullOrWhiteSpace(input);

        return validInputs.TryGetValue(input.ToLower(), out _);
    }
}
