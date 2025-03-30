# Custom Names

## Features
1. Custom names for beavers
1. Custom names for bots
1. Tracks names used to prevent duplicates
1. Configurable mod settings to support name tracking with multple save files (will require some work to update existing save files)

## Instructions

### Beaver Names
1. Download the mod
1. Create a text file called BeaverNames.txt
   -  Each line of the file will be a Beaver's name
1. Put the text file in your player data folder.
   -  Typical file path: **\Documents\Timberborn\
1. Open Timberborn
1. Select the mod
1. Create a new game or load an existing save

### Bot Names
1. Download the mod
1. Create a text file called BotNames.txt
   -  Each line of the file will be a Bot's name
1. Put the text file in your player data folder.
   -  Typical file path: **\Documents\Timberborn\
1. Open Timberborn
1. Select the mod
1. Create a new game or load an existing save


## Multiple Save Settings
This mod supports an optional mode to support multiple saves. This setting is off by default since it directly modifies your save data. Please read the below documentation before using this.

### Setting Name: MultipleSaveMode
**Purpose:** Use to have names tracked on a per save basis instead of per steam account basis.

**Notes:** This modifies your Timberborn save directly. Save files used with this setting will retain the name list after uninstalling the mod until either the name list reaches the end OR you use the RestoreDefaultNameList setting in this mod to clear them out sooner.

**Steps:**
1. Set MultipleSaveMode to true
2. Load Timberborn with the mod on
3. Open your save
4. Save your file again

**Result:** You have loaded the names from your text file into the Timberborn save data.

**Valid values:**
- true
- false 

### Setting Name: RestoreDefaultNameList
**Purpose:** Use to reset the pool of names back to their default values.

**Notes:** Existing beavers will keep their current name.

**Steps:**
1. Set ClearModNames to true
2. Load Timberborn with the CustomNameList mod on
3. Open your save
4. Save your file again

**Result:** Your save will be back to using the default name list from the Timberborn team.

**Valid values:**
- true
- false 

### Setting Name: RefreshModNameList
**Purpose:** MultipleSaveMode is on AND you wish to see the list of custom names immediately on an existing save.

OR you have added a lot of new names to the list that you want to see in the pool of names.

**Notes:** Duplicate beaver names may occur temporarily since the list is completely refreshed.

**Steps:**
1. Set ClearModNames to true
2. Load Timberborn with the CustomNameList mod on
3. Open your save
4. Save your file again
5. Close your game
6. Set RefreshModNameList setting back to false

**Result:** Your save will now include the most recent list of names. Steps 5 & 6 will help reduce the number of long-term duplicates you see.

**Valid values:**
- true
- false 
