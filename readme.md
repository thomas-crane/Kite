# Kite

**K**Relay L**ite**.

## Contents

+ [About](#about)
+ [Acknowledgements](#acknowledgements)
+ [Install](#install)
+ [Run](#run)
+ [Roadmap](#roadmap)

## About

Kite is a fork of KRelay which targets the .NET Core runtime.

There are a few major differences between Kite and KRelay:

+ Kite is cross-platform. It can run on Windows, MacOS and Linux.
+ It runs in the console instead of using a GUI.

Aside from these differences, Kite is just a fork of KRelay, so it works in exactly the same way.

## Install

1. Download [.NET Core 2.2](https://dotnet.microsoft.com/download/dotnet-core/2.2).
2. Download the [latest Kite release](https://github.com/thomas-crane/Kite/releases).
3. Download and run [Ninjin's XML Grabber](https://www.mpgh.net/forum/showthread.php?t=1342936). You should download all of the available XMLs.
4. When the XML Grabber is finished, put the XML files in the same folder as the Kite DLL.

## Run

Kite can be run using the dotnet command line utility.

```txt
dotnet Kite.dll
```

## Roadmap

Currently, Kite does not support loading plugins in the same way that KRelay does. The only thing Kite is currently capable of is running a proxy server that connects to the Australia server. The following list outlines the goals which need to be completed to make Kite more functional.

* [x] Run proxy server
* [ ] Support a configuration file
    * [ ] Stealth mode options
    * [ ] Change default server
* [ ] Support plugins

## Acknowledgements

+ Thanks to [@Ark Died](https://gitlab.com/Arkzzz) for the most up to date KRelay source code, of which this project is a fork.
+ Thanks to Ninjin for his XML Grabber tool.
+ Thanks to the original authors of KRelay for their work.