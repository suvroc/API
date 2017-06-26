# AnyStatus API

A library that contains the classes, interfaces and utilities needed for developing AnyStatus plugins.

[![Build status](https://ci.appveyor.com/api/projects/status/74kcwc63k0r2ajdj?svg=true)](https://ci.appveyor.com/project/AnyStatus/api)

## How it works

AnyStatus communicates with plugins using the API library. During startup, AnyStatus scans assemblies in the installation directory and registers all plugins.

A plugin is a set of classes that instruct AnyStatus how to display it in the dashboard and how to handle custom actions such as monitoring and triggering builds.

Plugins can be decorated with attributes such as DisplayName, Category and Description.

## Plugin Example

A class that defines the plugin.

<script src="https://gist.github.com/AlonAm/d37e580788eaec8d62858f5bb0cbd246.js"></script>

A class that handles monitor health checks.

<script src="https://gist.github.com/AlonAm/541ea7571b46f7404818f8c3a8eecf89.js"></script>
