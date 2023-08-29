# AD Enum Tool (adenumtool)

A tool written in C# for enumerating details about Active Directory domains and their domain controllers. This tool will be upgraded over time; right now, it only has some basic features.

## Features

- Fetch information about the current domain.
- Fetch information about all domains in the forest.
- Fetch details about all domain controllers in the current domain.
- Fetch details about all domain controllers across all domains in the forest.
- Write fetched details to an output file.

## Usage

Run the tool via the command line. You can provide the following commands:

- `Get-Domain`: Fetch information about the current domain.
- `Get-ForestDomain`: Fetch information about all domains in the forest.
- `Get-DomainController`: Fetch details about all domain controllers in the current domain.
- `Get-DomainControllerAll`: Fetch details about all domain controllers across all domains in the forest.
- `EveryThing`: Fetch all the above information.
- `NeedOutput`: Write the fetched details to an output file named `output.txt`.

### Example:

```
adenumtool.exe Get-Domain NeedOutput
```
This command fetches the current domain's information and writes it to output.txt.

```
adenumtool.exe Get-Domain
```
This command fetches the current domain's information and does not write output to file.

```
adenumtool.exe Get-Domain Get-ForestDomain
```
This command fetches the current domain's information and information about all domains in the forest.

```
adenumtool.exe EveryThing
```
This command fetches all the queries present int his tool.


# Requirements
- .NET Core SDK (for building and running).
- Necessary permissions to read Active Directory details.



