import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import {MemberListComponent} from "./members/member-list.component";
const routes: Routes = [
    {
        path: 'memberList',
        component: MemberListComponent
    },
    {
        path: '/TownHall/TownHall9',
        redirectTo: 'memberList'
    }
];

@
NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})
export class AppRoutingModule {}