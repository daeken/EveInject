# Tie stdout to the log service on stderr
import sys
sys.stdout = sys.stderr

# Expose compiled.code imports globally
import nasty
for key, value in nasty.nasty.mods.items():
	sys.modules[key] = value

# Display hidden module names
#print nasty.nasty.mods.keys()

## Quickly get module info.  Replace 'eve' with the module name
#import eve as mod
#print mod.__doc__
#print dir(mod)

# svc includes all services, but you can't instantiate them directly
# This will let you get a quick look at all the services available
import svc
ui = svc.gameui
print dir(ui)

# To use them, grab them from the eve object.  There's also RemoteSvc, but I
# don't know how to use it.
import eve
eve = eve.eve
gameui = eve.LocalSvc('gameui')
eve.Message('Foo!')
#gameui.MessageBox('Foo!') # Equivalent

# Set window title
eve.triapp.title = 'foo!'
