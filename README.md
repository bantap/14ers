# Colorado 14ers
### Paul Banta
### MSSA CAD 18-Week Project
### December, 2020
#

* [Database Design](DatabaseDesign.pdf)

Colorado residents tend to enjoy outdoor activities.
The Rocky Mountains provide a beautiful venue for Boating, Camping, Fishing, Hiking, and many other outdoor activities.

The Colorado Rocky Mountains contain 58 different peaks that are 14,000 feet high or more.
These are locally referred to as "14ers".
The most famous of these is Pikes Peak at 14,115 feet high located just west of Colorado Springs.
Many of these peaks have trails to the top.
One popular outdoor activity in the state is to "hike a 14er".

A few years ago, in 2014, there was a campaign or a challenge in the state for people to "Hike 14 14ers In 2014".
This typifies a bit of a competitive nature of avid hikers to "check off" which 14ers they have "summitted".

This application will allow users to keep track of which 14ers they have summitted.

Users will be allowed to create an account at this website (register).
Once registered and logged in, the main functionality will allow users to enter each peak they have summitted.
Each entry will include a number of pieces of information, including:
* Date Summitted (required)
* Which Peak (required, from a pre-populated list)
* Which Trail (optional, default value based on peak)
* Distance (optional, default value based on peak and/or trail)
* Starting Elevation (required, modifiable, default value based on peak and/or trail)
* Elevation (required, no modification, based on peak)
* Start Time (optional)
* Summit Time (optional)
* Finish Time (optional)
* Trail Condition (optional)
* Weather Condition (optional)
* Difficulty Level (1 - 5, optional)
* Notes (free-form text, optional)

Users will be allowed to create an entry for each and every peak that they have summitted.
This will include allowing users to summit the same peak multiple times.

Users will be allowed to upload a picture from each hike.
We call this a "summit selfie".

Users will be allowed to retrieve summary information about their entries.
They will be allowed to retrieve their number of summits and their total distance on a month-by-month basis as well as on a year-to-year basis.
Other summary information will be added as needed.

Users will also be able to research peak conditions on a peak-by-peak basis from previous hikers (anonymously).
If a user wants to hike a particular peak, they will be able to choose that peak and retrieve recent trail conditions, weather conditions, difficulty level, and notes from other hikers (anonymous) who have hiked that peak recently.
Users doing this research will be allowed to flag inappropriate information by other users.
Administrator users will receive these flags and have some ability to mitigate.

Users will also be able to organize groups of hikers for future hikes.
If a user wants to hike a particular peak, they will have a mechanism to add their contact information into a "pool" of hikers based on peak and date.
The details on this functionality are subject to change due to safety concerns.

A few users will be allowed to be administrators.
These users will be allowed to maintain the list of peaks and trails.
These users will also be allowed to view all users "shared" information (trail conditions, weather conditions, and notes).
In the event that "shared" information is inappropriate, an admin user will be allowed to either delete the offensive material or even disable an account.

Reference: www.14ers.com
