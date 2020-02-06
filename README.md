# Parameter Binding Demo

[Read the docs here](https://docs.microsoft.com/en-us/aspnet/web-api/overview/formats-and-model-binding/parameter-binding-in-aspnet-web-api#value-providers)


## Default Binding

Simple type (.Net Primatives, TimeSpan,DateTime, Guid, decimal and string) bind from the URI
Complex types bind from the Message body using a media-type formatter

This can be overriden by using the [FromUri] and [FromBody] attributes

At most one parmeter is allowed to read the message body.

## Type Converters

Type convertors allow the WebAPI to treat a class as a simple type so that they can be bound from the Uri.

## Model Binders

Model binders are a more flexible mechanism than type convertors as they allow access to the Http Request, Route Data and action description

Model binder gets its input values from a value provider.

- The value provider takes the requets and populates a dictionary of key value pairs
- The model binder uses that dictionary to create the model

Out of the box model binders have value providers for the QueryString and the RouteData

## HttpParameterBinding

This it the general mechanism from which Model binding is built on. 

The ParameterBindingRules on the HttpConfiguration privdes a hook for custom binding logic.

## IActionValueBinder

Pluggable service for the binding behaviour, the default implementation is

1. Look for a ParameterBindingAttribute e.g. FromBody, FromUri, ModelBinder 
2. Use the ParameterBindingRules
3. Default Binding

## View the source 

https://github.com/aspnet/AspNetWebStack/tree/master/src/System.Web.Http







