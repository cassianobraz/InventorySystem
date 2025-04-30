import { SideBar } from "../components/SideBar";

export function Dashboard() {
    return (
        <div className="flex flex-row">
            <SideBar/>
            <div>
                <h1>Dashboard</h1>
            </div>
        </div>
    )
}