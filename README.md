# dynamicDI
injections based on provided key

In any service, inject `ServiceForModelProvider`. 

At any point get a service:

```c#
var service = _serviceForModelProvider.SetService("<your model>");
```

Based on the incoming request, model selection can also be pre-set into `_serviceForModelProvider` to make sure `SetService("<your model>")` need not be called each time. 

- For controllers, use `ModelService` attribute. Check the `SampleController` for examples.
- For endpoints, use `WithModelService()`. Check the startup class for an example.

Once either of the above two are used, you can use `_serviceForModelProvider.Service` to access the selected service. Check `SampleController` for an example. 