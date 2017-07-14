#import <Foundation/Foundation.h>
#import <ScriptingBridge/ScriptingBridge.h>
#import "ChromeTabInfo.h"

@interface ChromeScripting : NSObject

-(id)initWithBundleName:(NSString*)bundleName;

-(SBObject*)activeWindow;
-(SBObject*)activeTab;

-(NSArray<NSObject*>*)allTabs;

-(void)activate;
-(void)openTab:(NSString*)url;

@end
