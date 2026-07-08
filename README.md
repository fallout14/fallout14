Here is the translation with the original Markdown formatting preserved:

# Fallout 14

**Fallout 14** is a sidestream fork of **[Nuclear 14](https://github.com/Misfit-Sanctuary/nuclear-14)** — the first Fallout-themed fork for Space Station 14, originally created by Peptide90 in 2022 with contributions from the community. While Nuclear 14 / Misfits continues along its own trajectory, Fallout 14 explores a different direction with expanded systems, rebalanced gameplay, and a distinct vision for the wasteland.

## About the Project

Fallout 14 builds on the foundation of Nuclear 14 and the upstream Einstein Engines repository, utilizing:

- Assets from various Fallout13 (F13/SS13) builds — Desert Rose 2, Lone Star, and more
- Unique materials created by the community
- A highly modular system from Einstein Engines

The theme and locations differ from classic F13, offering players a new experience. The codebase is licensed under AGPLv3, which allows for free use and development of the project.

## Features

Fallout 14 adds:

- Expanded and rebalanced gameplay systems distinct from upstream
- Regular updates and active development
- A unique take on the Fallout wasteland experience

To participate in development, join our [Discord](https://discord.gg/yXsJnq3FbU).

## Links

- [Discord](https://discord.gg/yXsJnq3FbU) (official community)
- Game servers: via launcher (`tbd`) or in Discord

## Building

### Requirements

- Git
- .NET SDK 10.0.101

### Windows

1. Clone the repository:

```
git clone https://github.com/fallout14/fallout14.git
```

1. Initialize submodules:

```
git submodule update --init --recursive
```

1. Build the project:

```
Scripts/bat/buildAllDebug.bat
```

1. Run client and server:

```
Scripts/bat/runQuickAll.bat
```

1. Connect to localhost via the client

### Linux

Similar to Windows, but use the `.sh` scripts:

```
Scripts/sh/buildAllDebug.sh
Scripts/sh/runQuickAll.sh
```

### MacOS

Theoretically similar to Linux, but has not been tested

## License

Detailed information about code and asset licensing is available in [LEGAL.md](./LEGAL.md). Key provisions:

- Code: AGPLv3
- Assets: individual licenses (check meta.json)
- Copyright compliance is mandatory

