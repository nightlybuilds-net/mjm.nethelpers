# Welcome to mjm.nethelpers!

This repo contains a collection of helpers and extensions method for .net. Cool!

[![Build Status](https://dev.azure.com/nightlybuilds-net/mjm.nethelpers/_apis/build/status/markjackmilian.mjm.nethelpers?branchName=master)](https://dev.azure.com/nightlybuilds-net/mjm.nethelpers/_build/latest?definitionId=15&branchName=master)

## Signatures
Below the signatures that will provide you a nicer and clearer code style

### Bool

    bool  IsTrue(this  bool  value)
    bool  IsFalse(this  bool  value)

### Enumerable
    bool  IsNullOrEmpty<T>(this  IEnumerable<T> enumerable)
    bool  IsEmpty<T>(this  IEnumerable<T> enumerable)
### Generic
    T  Clamp<T>(this  T  value, T  min, T  max) where  T : IComparable

### object
    bool  IsNull(this  object  obj)
    bool  IsNotNull(this  object  obj)
    bool  Is<T>(this  object  obj)
    T  To<T>(this  object  obj)
    T  SafelyTo<T>(this  object  obj) where  T : class
    string  PropertiesToString(this  object  obj)
    string  ToJson(this  object  obj, JsonSerializerOptions  options  =  null)

### String
    T  FromJson<T>(this  string  json, JsonSerializerOptions  options  =  null)
    bool  IsNullOrEmpty(this  string  text)
    bool  IsNullOrWhiteSpace(this  string  text)
    T  Parse<T>(this  string  text)
    T  TryParse<T>(this  string  text)
    DateTime ParseDateTime(this string text, CultureInfo cultureInfo = null, DateTimeStyles dateTimeStyles = DateTimeStyles.None)
    DateTime TryParseDateTime(this string text, CultureInfo cultureInfo = null, DateTimeStyles  dateTimeStyles  =  DateTimeStyles.None)

### Task
    Task<TResult> TimeoutAfter<TResult>(this  Task<TResult> task, TimeSpan  timeout
