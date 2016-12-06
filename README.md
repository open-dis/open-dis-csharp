# open-dis-csharp
C-Sharp implementation of the Distributed Interactive Simulation (DIS) standard

## Git Submodules

This repo uses a submodule to hold the XML description files for the DIS protocol.
If you want to regenerate the code--which you probably don't want to do--make
sure the XML files are present by loading the submodule:

~~~~
git submodule init
git submodule update
~~~~
