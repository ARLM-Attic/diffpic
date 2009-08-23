DiffPic v1.0 (c) 2009 by CMG Lee & Timwi

DiffPic is a simple picture comparer with a minimal user interface
to maximise the viewing area. Mouse buttons switch between
two JPEG, PNG, (non-animated) GIF, BMP or TIFF images,
an Exclusive-or of them and a custom difference highlighter.
Images can be panned and zoomed. DiffPic is developed in C#.

Images (called Pic 1 and Pic 2) can be loaded into DiffPic by

1. Entering their full path names into the text boxes,
2. Clicking the buttons and browsing for their files,
3. Dragging their files into the text boxes from Windows Explorer,
4. Dragging their files into the main panel from Windows Explorer,
5. Dragging their files into the DiffPic.exe executable file, or
6. Using command-line parameters e.g DiffPic.exe pic1.jpg pic2.png

After the images are loaded, pressing

1. Neither mouse button shows Pic 1,
2. Only the left button shows Pic 2,
3. Only the right button highlights the differences.
   [reds indicate pixels in Pic 1 darker than in Pic 2
    (the more yellow, the greater the difference) and
    blues indicate pixels in Pic 1 brighter than in Pic 2
    (the more cyan, the greater the difference);
    the brightness value is computed as
    30% of red + 59% of green + 11% of blue channels],
4. Both buttons show an Exclusive-or of both images.

The image can be panned by dragging with either button, and
zoomed with the scroll wheel or selecting from the zoom % text box.
