﻿
using System;

namespace Nika1337.Library.ApplicationCore.Exceptions;

public class EmailTemplateNotFoundException : Exception
{
    public EmailTemplateNotFoundException(string templateName) : base($"No email template found with name '{templateName}'") { 
    }

    public EmailTemplateNotFoundException(int templateId) : base($"No email template found with id '{templateId}'")
    {

    }
}