# portals-2D-Unity
We create a 2D Portal system just like in the orignal Portal games.

There are 4 scripts in the file-
1.gun
2.portal_ball
3.PlayerS
4.PortalS

Overview
The player has a portal gun which it uses to create portals(red/blue) on walls. At any instance of time there can be a maximum of one red portal and one blue portal. When the player enters one portal he exits through the other portal maintaining its velocity relative to the first portal.
This is achieved by creating a gun which shoots portal balls. The portal ball is either red or blue (you can use different prefabs to differentiate) and once incident on a wall creates a portal of its colour. 
When a player enters one portal, it is destroyed and recreated at the other portal. This only takes care of position. The tricky part is to transfer the velocity which is achieved using the concepts of linear angular transformation or rotation of axes.
https://en.wikipedia.org/wiki/Rotation_of_axes for more details.
