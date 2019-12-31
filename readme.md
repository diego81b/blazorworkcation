

To apply Tailwind to the **blazortest.css** file, I ran the following command:
```

npm run build
```

> It would be nice if I could get Visual Studio to run the above command anytime a file is altered (with a guarantee that it will wait for said compilation when debugging the app) and have Visual Studio show me the errors. But that's another kettle of fish/much more difficult. So I settled on the following workflow.

When I'm debugging on my machine, I run this command in an open terminal:

```

npm run watch

```

Whenever a .css file changes, a new **balzortest.css** file is generated. Which works fine while the app is running - I just have to refresh the page after I've made a change.

For running the build every visual studio build command:

> Go to BlazorApp.Web Properties > Build Events > edit Pre-build event command > add **`npm run build`** script
