===============
Getting Started
===============

Installation:

* Python 2: ``pip2 install pycairo``
* Python 3: ``pip3 install pycairo``

Installing Pycairo requires pkg-config and cairo including its headers. Here
are some examples on how to install those for some platforms:

* Ubuntu/Debian: ``sudo apt install libcairo2-dev pkg-config``
* macOS/Homebrew: ``brew install cairo pkg-config``
* Arch Linux: ``sudo pacman -S cairo pkgconf``
* Fedora: ``sudo dnf install cairo-devel pkg-config``
* openSUSE: ``sudo zypper install cairo-devel pkg-config``

To verify that the installation works run the following Python code:

.. code:: python

    import cairo
