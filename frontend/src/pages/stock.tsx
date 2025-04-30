import { SideBar } from "../components/SideBar";

export function Stock() {
    return (
        <div className="flex flex-row">
            <SideBar />
            <div>
                <h1>Estoque</h1>
            </div>
        </div>
    )
}