﻿namespace Presentation.API;

public interface IErrorInformer
{
    void InformError(string message);

    void InformSuccess(string message);

    string GetRecentMessage();
}
